using System;

namespace Stakeholder.Utils
{
    /// <summary>
    /// Very important output Concole class. It is like Console but a bit different. 
    /// Do not touch it or it will break.
    /// </summary>
    public static class Concole
    {
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteLine(ConsoleColor color, string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        public static void Write(string message)
        {
            Console.Write(message);
        }

        public static void Write(ConsoleColor color, string message)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = oldColor;
        }

        public static void Write(bool ignoreColor, ConsoleColor color, string message)
        {
            if (ignoreColor) Write(message);
            else Write(color, message);
        }
        public static void WriteLine(bool ignoreColor, ConsoleColor color, string message)
        {
            if (ignoreColor) WriteLine(message);
            else WriteLine(color, message);
        }
    }
}
