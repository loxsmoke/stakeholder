using Stakeholder.Enums;
using System;
using System.Linq;

namespace Stakeholder;
public class Args
{
    /// Type of development activity to simulate
    public DevelopmentType DevType { get; set; }

    /// Level of technical jargon in output
    public JargonLevel Jargon { get; set; }

    /// How busy and complex the output should appear
    public Complexity Complexity { get; set; }

    /// Duration in seconds to run (0 = run until interrupted)
    public long Duration { get; set; }

    /// Show critical system alerts or issues
    public bool Alerts { get; set; }

    /// Simulate a specific project
    public string Project { get; set; } = string.Empty;

    /// Use less colorful output
    public bool Minimal { get; set; }

    /// Show team collaboration activity
    public bool Team { get; set; }

    /// Simulate a specific framework usage
    public string Framework { get; set; } = string.Empty;

    /// <summary>
    /// Parse without any error handling whatsoever.
    /// If you are faking activity then you have to do it carefully and put effort into it. 
    /// No sloppy command lines. No errors allowed.
    /// </summary>
    /// <param name="arguments">arguments?</param>
    /// <returns>Arguments!</returns>
    public static Args Parse(string[] arguments)
    {
        return new()
        {
            DevType = ParseEnum(arguments, "d", "dev_type", DevelopmentType.Backend),
            Jargon = ParseEnum(arguments, "j", "jargon", JargonLevel.Medium),
            Complexity = ParseEnum(arguments, "c", "complexity", Complexity.Medium),
            Duration = ParseLong(arguments, "T", "duration", 0),
            Alerts = ParseBool(arguments, "a", "alerts"),
            Project = GetValue(arguments, "p", "project") ?? "distributed-cluster",
            Minimal = ParseBool(arguments, "m", "minimal"),
            Team = ParseBool(arguments, "t", "team"),
            Framework = GetValue(arguments, "F", "framework") ?? ""
        };
    }

    public static T ParseEnum<T>(string[] args, string shortName, string name, T defaultValue) where T : struct, Enum
    {
        return Enum.TryParse<T>(GetValue(args, shortName, name), ignoreCase: true, out T value) ? value : defaultValue;
    }
    public static long ParseLong(string[] arguments, string shortName, string name, long defaultValue)
    {
        return long.TryParse(GetValue(arguments, shortName, name), out long value) ? value : defaultValue;
    }
    public static bool ParseBool(string[] arguments, string shortName, string name, bool defaultValue = false)
    {
        return (arguments.Contains($"-{shortName}") || arguments.Contains($"--{name}")) ? true : defaultValue;
    }

    /// <summary>
    /// Get a specific argument from the command line arguments
    /// </summary>
    /// <param name="arguments">Command line arguments</param>
    /// <param name="shortName">The short name</param>
    /// <param name="longName">The long name</param>
    /// <returns>The argument value if present.Null otherwise</returns>
    public static string? GetValue(string[] arguments, string shortName, string longName)
    {
        string shortNameWithHyphen = $"-{shortName}";
        string longNameWithHyphen = $"--{longName}";
        for (int i = 0; i < arguments.Length; i++)
        {
            if ((arguments[i] == shortNameWithHyphen || 
                arguments[i] == longNameWithHyphen) &&
                i + 1 < arguments.Length)
            {
                return arguments[i + 1];
            }
        }
        return null;
    }
}
