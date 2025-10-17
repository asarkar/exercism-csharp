using System.Globalization;
using System.Text;

using Microsoft.VisualBasic;

internal static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        List<string> buf = [];
        if (id.HasValue) // `is not null` or `!= null` also works
        {
            buf.Add($"[{id}]");
        }
        buf.Add(name);
        buf.Add(department?.ToUpper(CultureInfo.InvariantCulture) ?? "OWNER");

        return string.Join(" - ", buf);
    }
    // Syntax for nested string interpolation.
    // $"{(id == null ? "" : $"[{id}]")} "
}