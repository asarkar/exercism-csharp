using System.Globalization;

using Microsoft.VisualBasic;

internal static class LogLine
{
    public static string Message(string logLine) =>
        logLine.Split(' ', 2)[1].Trim();

    public static string LogLevel(string logLine)
    {
        var level = logLine.Split(':', 2)[0];
        return level[1..(level.Length - 1)].ToLower(CultureInfo.InvariantCulture);
    }

    public static string Reformat(string logLine) =>
        $"{Message(logLine)} ({LogLevel(logLine)})";
}