using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    private static readonly Dictionary<Location, TimeZoneInfo> Location2TimeZoneIds =
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? new()
            {
                [Location.London] = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
                [Location.NewYork] = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
                [Location.Paris] = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"),
            }
            : new()
            {
                [Location.London] = TimeZoneInfo.FindSystemTimeZoneById("Europe/London"),
                [Location.NewYork] = TimeZoneInfo.FindSystemTimeZoneById("America/New_York"),
                [Location.Paris] = TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"),
            };

    public static DateTime ShowLocalTime(DateTime dtUtc) =>
        dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        // 1. Parse to local DateTime (unspecified kind).
        var localTime = DateTime.ParseExact(
            appointmentDateDescription,
            "M/d/yyyy HH:mm:ss",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None
        );

        // 2. Get target time zone.
        TimeZoneInfo tz = Location2TimeZoneIds[location];

        // 3. Convert that local time to UTC.
        return TimeZoneInfo.ConvertTimeToUtc(localTime, tz);

    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) =>
        alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1.0),
            AlertLevel.Standard => appointment.AddHours(-1.0).AddMinutes(-45.0),
            _ => appointment.AddMinutes(-30.0)
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        TimeZoneInfo tz = Location2TimeZoneIds[location];
        return Enumerable.Range(0, 7)
            .Any(i => tz.IsDaylightSavingTime(dt.AddDays(-i)));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var fmt = location switch
        {
            Location.NewYork => "M/d/yyyy HH:mm:ss",
            _ => "d/M/yyyy HH:mm:ss"
        };
        return DateTime.TryParseExact(
                dtStr,
                fmt,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime result
            )
            ? result
            : DateTime.MinValue;
    }
}