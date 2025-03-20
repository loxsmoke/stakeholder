using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Stakeholder.Utils
{
    /// <summary>
    /// Custom built progress bar. Supports only a few fields and colors. 
    /// Custom implementation with strong opinion about colors.
    /// Does not like magenta.
    /// </summary>
    public class ProgressBar
    {
        public int Value { get; private set; }
        public int MaxValue { get; private set; }
        public string ProgressChars { get; set; } = "▰▱▱";
        public string Template { get; set; }

        #region Private properties
        Stopwatch Clock { get; set; }
        string spinnerChars = "⠁⠁⠉⠙⠚⠒⠂⠂⠒⠲⠴⠤⠄⠄⠤⠠⠠⠤⠦⠖⠒⠐⠐⠒⠓⠋⠉⠈⠈ ";
        int spinnerIndex;
        enum FieldType
        {
            Text,
            Spinner,
            Elapsed,
            Bar,
            Pos,
            Len,
            Eta
        }
        record Field(FieldType Type, string Value, ConsoleColor? Color = null, ConsoleColor? SecondColor = null, int? Width = null);
        readonly List<Field> Fields = [];
        int maxProgressLength;
        #endregion

        public ProgressBar(int max, string template)
        {
            Clock = Stopwatch.StartNew();
            MaxValue = max;
            Template = template;
        }

        #region Template parsing
        /// <summary>
        /// The world needs advanced console progress bar like this.
        /// At least it is not XML
        /// </summary>
        // "{spinner:.green} [{elapsed_precise}] [{bar:40.cyan/blue}] {pos}/{len} files ({eta})"
        // "{spinner:.yellow} [{elapsed_precise}] [{bar:40.yellow/blue}] {pos}/{len} samples ({eta})"
        // "{spinner:.green} [{elapsed_precise}] [{bar:40.green/blue}] {pos}/{len} seconds"
        // "{spinner:.blue} [{elapsed_precise}] [{bar:30.cyan/blue}] {pos}/{len}"
        // "{spinner:.green} [{elapsed_precise}] [{bar:40.cyan/blue}] {pos}/{len} ({eta})"
        protected void Parse()
        {
            // Parse Template property. Formatted fields in the string:
            // {simple}
            // {colorful:.color}
            // {doubleColor:width.color1/color2}

            bool field = false;
            bool width = false;
            bool color1 = false;
            bool color2 = false;

            string text = "";

            string fieldName = "";
            string fieldWidth = "";
            string fieldColor1 = "";
            string fieldColor2 = "";
            foreach (var c in Template)
            {
                if (c == '{')
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        Fields.Add(new Field(FieldType.Text, text));
                        text = string.Empty;
                    }

                    field = true;
                    width = color1 = color2 = false;
                    fieldName = string.Empty;
                    continue;
                }

                if (field)
                {
                    if (c == '}')
                    {
                        field = false;
                        AddField(fieldName, fieldWidth, fieldColor1, fieldColor2);
                        continue;
                    }

                    if (c == ':')
                    {
                        width = true;
                        continue;
                    }
                    else if (c == '.')
                    {
                        width = false;
                        color1 = true;
                        continue;
                    }
                    else if (c == '/')
                    {
                        color1 = false;
                        color2 = true;
                        continue;
                    }

                    if (width) fieldWidth += c.ToString();
                    else if (color1) fieldColor1 += c.ToString();
                    else if (color2) fieldColor2 += c.ToString();
                    else fieldName += c.ToString();
                }
                else
                {
                    text += c.ToString();
                }
            }

            if (!string.IsNullOrEmpty(text))
            {
                Fields.Add(new Field(FieldType.Text, text));
            }
        }

        void AddField(string fieldName, string fieldWidth, string fieldColor1, string fieldColor2)
        {
            var fieldType = fieldName switch
            {
                "spinner" => FieldType.Spinner,
                "elapsed_precise" => FieldType.Elapsed,
                "bar" => FieldType.Bar,
                "pos" => FieldType.Pos,
                "len" => FieldType.Len,
                "eta" => FieldType.Eta,
                _ => throw new ArgumentException("Unknown field type")
            };

            if (int.TryParse(fieldWidth, out int width))
            {
                Fields.Add(new Field(fieldType, string.Empty, ParseColor(fieldColor1), ParseColor(fieldColor2), width));
            }
            else 
            {
                Fields.Add(new Field(fieldType, string.Empty, ParseColor(fieldColor1), ParseColor(fieldColor2)));
            }
        }

        /// <summary>
        /// F other colors. I only like green, yellow, blue and cyan.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        ConsoleColor? ParseColor(string color) => 
            color switch
            {
                "green" => ConsoleColor.Green,
                "yellow" => ConsoleColor.Yellow,
                "blue" => ConsoleColor.Blue,
                "cyan" => ConsoleColor.Cyan,
                _ => ConsoleColor.White,
            };
        #endregion

        #region Output
        public void Write()
        {
            if (Fields.Count == 0 && !string.IsNullOrWhiteSpace(Template))
            {
                Parse();
            }

            var (x, y) = Console.GetCursorPosition();
            var defaultColor = Console.ForegroundColor;
            Console.CursorVisible = false;
            foreach (var field in Fields)
            {
                switch (field.Type)
                { 
                    case FieldType.Spinner:
                        Console.ForegroundColor = field.Color!.Value;
                        if (++spinnerIndex == spinnerChars.Length) spinnerIndex = 0;
                        Console.Write(spinnerChars[spinnerIndex]);
                        break;
                    case FieldType.Bar:
                        Console.ForegroundColor = defaultColor;
                        WriteBar(field);
                        break;
                    case FieldType.Pos:
                        Console.ForegroundColor = defaultColor;
                        Console.Write(Value);
                        break;  
                    case FieldType.Len:
                        Console.ForegroundColor = defaultColor;
                        Console.Write(MaxValue);
                        break;
                    case FieldType.Eta:
                        Console.ForegroundColor = defaultColor;
                        Console.Write(CalculateEta().ToString("hh\\:mm\\:ss"));
                        break;
                    case FieldType.Elapsed:
                        Console.ForegroundColor = defaultColor;
                        Console.Write(Clock.Elapsed.ToString("hh\\:mm\\:ss"));
                        break;
                    case FieldType.Text:
                        Console.ForegroundColor = defaultColor;
                        Console.Write(field.Value);
                        break;
                }
            }
            maxProgressLength = Math.Max(maxProgressLength, Console.CursorLeft);
            Console.CursorLeft = x;
            Console.ForegroundColor = defaultColor;
        }

        void WriteBar(Field field)
        {
            var completed = Value * field.Width!.Value / MaxValue;
            var remaining = field.Width!.Value - completed;
            if (field.Color.HasValue)
            {
                Console.ForegroundColor = field.Color!.Value;
            }
            Console.Write(new string(ProgressChars[0], completed));

            if (remaining <= 0) return;

            if (field.SecondColor.HasValue)
            {
                Console.ForegroundColor = field.SecondColor!.Value;
            }
            Console.Write(new string(ProgressChars[2], remaining));
        }

        TimeSpan CalculateEta()
        {
            if (Value == 0 ||
                Value >= MaxValue)
            { 
                return TimeSpan.Zero;
            }

            var elapsed = Clock.Elapsed.TotalMilliseconds;
            var estimataedTotal = elapsed * MaxValue / Value;
            return TimeSpan.FromMilliseconds(estimataedTotal - elapsed);
        }

        public void SetPosition(int pos)
        {
            Value = Math.Min(MaxValue, pos + 1);
            Write();
            if (Value >= MaxValue)
            {
                Finish();
            }
        }

        public void WriteLine(string text)
        {
            ClearLine();
            Console.WriteLine(text);
        }

        public void ClearLine()
        {
            Console.Write(new string(' ', maxProgressLength));
            Console.CursorLeft = 0;
        }
        public void Finish()
        {
            ClearLine();
            Console.CursorVisible = true;
        }
        public void FinishAndClear()
        {
            Finish();
            Console.CursorVisible = true;
        }
        #endregion
    }
}
