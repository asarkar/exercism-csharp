using System.Text.RegularExpressions;

public static class LogAnalysis
{
    public static string SubstringAfter(this string s, string delimiter) =>
        s.Split(delimiter, 2)[1];

    public static string SubstringBetween(this string s, string left, string right)
    {
        var pattern = $"{Regex.Escape(left)}(.+){Regex.Escape(right)}";
        Match m = Regex.Match(s, pattern);
        return m.Success
            ? m.Groups[1].Value
            : throw new ArgumentException(
                $"No portion of string '{s}' is enclosed between '{left} and '{right}'");
    }

    public static string Message(this string s) =>
        s.SubstringAfter(": ");

    public static string LogLevel(this string s) =>
        s.SubstringBetween("[", "]");
}