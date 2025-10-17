using System.Text.RegularExpressions;

#pragma warning disable CA1822
public partial class LogParser
{
    // SYSLIB1045: Use GeneratedRegexAttribute to generate the regular expression 
    // implementation at compile time.
    // The `|` operator has lower precedence than the `^` anchor, so
    // the pattern needs to be grouped or else the `^` only applies to TRC. 
    [GeneratedRegex(@"^\[(?:TRC|DBG|INF|WRN|ERR|FTL)\]")]
    private static partial Regex IsValidLineRegex(); // Note the static partial method

    [GeneratedRegex(@"<[\^*=-]+>")]
    private static partial Regex SplitLogLineRegex();

    [GeneratedRegex("\".*password.*\"", RegexOptions.IgnoreCase)] // @"\"".*password.*\"""
    private static partial Regex CountQuotedPasswordsRegex();

    [GeneratedRegex(@"end-of-line\d+")]
    private static partial Regex RemoveEndOfLineRegex();

    [GeneratedRegex(@"(password\S+)", RegexOptions.IgnoreCase)]
    private static partial Regex WeakPasswordRegex();

    public bool IsValidLine(string text) =>
        IsValidLineRegex().IsMatch(text);

    public string[] SplitLogLine(string text) =>
        SplitLogLineRegex().Split(text);

    public int CountQuotedPasswords(string lines) =>
        lines.Split([Environment.NewLine], StringSplitOptions.RemoveEmptyEntries)
            .Count(line => CountQuotedPasswordsRegex().IsMatch(line));

    public string RemoveEndOfLineText(string line) =>
        RemoveEndOfLineRegex().Replace(line, string.Empty);

    public string[] ListLinesWithPasswords(string[] lines) =>
        [.. lines
            .Select(line =>
            {
                Match m = WeakPasswordRegex().Match(line);
                return $"{(m.Success ? m.Groups[1] : "--------")}: {line}";
            }
            )];
}
#pragma warning restore CA1822