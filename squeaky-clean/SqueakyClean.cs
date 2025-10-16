using System.Globalization;

public static class Identifier
{
    private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");
    public static string Clean(string identifier)
    {
        var buf = new System.Text.StringBuilder();
        for (var i = 0; i < identifier.Length; i++)
        {
            var c = identifier[i];
            if (char.IsWhiteSpace(c))
            {
                _ = buf.Append('_');
            }
            else if (char.IsControl(c))
            {
                _ = buf.Append("CTRL");
            }
            else if (!char.IsLetter(c) || IsGreekLetter(c))
            {
                continue;
            }
#pragma warning disable IDE0045
            else if (i > 0 && identifier[i - 1] == '-')
            {
                _ = buf.Append(char.ToUpper(c, Culture));
            }
#pragma warning restore IDE0045
            else
            {
                _ = buf.Append(c);
            }
        }
        return buf.ToString();
    }
    private static bool IsGreekLetter(char c) => char.IsBetween(c, 'α', 'ω');
}