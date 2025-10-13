public static class Identifier
{
    public static string Clean(string identifier)
    {
        var buf = new System.Text.StringBuilder();
        for (int i = 0; i < identifier.Length; i++)
        {
            var c = identifier[i];
            if (Char.IsWhiteSpace(c))
            {
                buf.Append('_');
            }
            else if (Char.IsControl(c))
            {
                buf.Append("CTRL");
            }
            else if (!Char.IsLetter(c) || IsGreekLetter(c))
            {
                continue;
            }
            else if (i > 0 && identifier[i - 1] == '-')
            {
                buf.Append(Char.ToUpper(c));
            }
            else
            {
                buf.Append(c);
            }
        }
        return buf.ToString();
    }
    private static bool IsGreekLetter(char c) => char.IsBetween(c, 'α', 'ω');
}
