using System.Globalization;

public static class HighSchoolSweethearts
{
    private static readonly string[] Banner =
@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**                         **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    public static string DisplaySingleLine(string studentA, string studentB) =>
        CenterAlign('♡', studentA, studentB, 61);

    private static string CenterAlign(char centerElement, string left, string right, int width)
    {
        var msg = $"{left} {centerElement} {right}";
        // Placing the element at the center leaves width/2 spaces on each side,
        // two of which are consumed by the spaces on each side of the center element. 
        var leftPadding = (width / 2) - 1 - left.Length;
        // var rightPadding = width - leftPadding - msg;

        return msg.PadLeft(leftPadding + msg.Length).PadRight(width);
        // This works too.
        // return new string(' ', leftPadding) + message + new string(' ', rightPadding);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        var banner = (string[])Banner.Clone();
        // For some reason, the test passes the names with weird spaces.
        // Subtract 4 for the asterisks at the beginning and end of the line.
        var names = CenterAlign('+', studentA, $" {studentB}", banner[5].Length - 4);
        banner[5] = $"**{names}**";
        return string.Join(Environment.NewLine, banner);
    }

    public static string DisplayGermanExchangeStudents(string studentA, string studentB,
        DateTime start, float hours) =>
        // "d" means Short date pattern.
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
        // "N2" means Number format with 2 decimal places.
        // https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        // CultureInfo("de-DE") sets:
        //     , as the decimal separator
        //     . as the thousands separator
        string.Create(
            CultureInfo.GetCultureInfo("de-DE"),
            $"{studentA} and {studentB} have been dating since {start:d} - that's {hours:N2} hours");
}