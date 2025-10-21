using System.Globalization;
using System.Text.RegularExpressions;

internal static class SwiftScheduling
{
    private static DateTime AtHour(this DateTime date, int hour) =>
        date.Date.AddHours(hour);

    private static DateTime ToTargetDay(this DateTime datetime, DayOfWeek targetDay)
    {
        DayOfWeek day = datetime.DayOfWeek;
        var offset = day == targetDay ? 0 : targetDay - day + (day < targetDay ? 0 : 7);
        return datetime.AddDays(offset);
    }

    private static DateTime ToTargetMonth(this DateTime datetime, string n)
    {
        var targetMonth = int.Parse(n, CultureInfo.InvariantCulture);
        var year = datetime.Month < targetMonth ? datetime.Year : datetime.Year + 1;
        var firstDayOfNthMonth = new DateTime(year, targetMonth, 1, 8, 0, 0);
        return firstDayOfNthMonth.DayOfWeek switch
        {
            >= DayOfWeek.Monday and <= DayOfWeek.Friday => firstDayOfNthMonth,
            _ => firstDayOfNthMonth.ToTargetDay(DayOfWeek.Monday)
        };
    }

    private static DateTime ToTargetQuarter(this DateTime datetime, string n)
    {
        var targetQuarter = int.Parse(n, CultureInfo.InvariantCulture);
        var currentQuarter = (int)Math.Ceiling(datetime.Month / 3.0);
        var year = currentQuarter <= targetQuarter ? datetime.Year : datetime.Year + 1;
        var month = targetQuarter * 3;
        var daysInMonth = DateTime.DaysInMonth(year, month);
        var lastMonthOfTargetQuarter = new DateTime(year, month, daysInMonth, 8, 0, 0);
        return lastMonthOfTargetQuarter.DayOfWeek switch
        {
            DayOfWeek.Sunday => lastMonthOfTargetQuarter.AddDays(-2),
            DayOfWeek.Saturday => lastMonthOfTargetQuarter.AddDays(-1),
            _ => lastMonthOfTargetQuarter
        };
    }

#pragma warning disable SYSLIB1045
    public static DateTime DeliveryDate(DateTime meetingStart, string description) =>
        description switch
        {
            "NOW" => meetingStart.AddHours(2),
            "ASAP" when meetingStart.Hour < 13 => meetingStart.AtHour(17),
            "ASAP" => meetingStart.AddDays(1).AtHour(13),
            "EOW" when meetingStart.DayOfWeek is >= DayOfWeek.Monday and <= DayOfWeek.Wednesday =>
                meetingStart.ToTargetDay(DayOfWeek.Friday).AtHour(17),
            "EOW" when meetingStart.DayOfWeek is DayOfWeek.Thursday or DayOfWeek.Friday =>
                meetingStart.ToTargetDay(DayOfWeek.Sunday).AtHour(20),
            var s when Regex.Match(s, @"(\d+)M") is Match m && m.Success =>
                meetingStart.ToTargetMonth(m.Groups[1].Value),
            var s when Regex.Match(s, @"Q(\d+)") is Match m && m.Success =>
                meetingStart.ToTargetQuarter(m.Groups[1].Value),
            _ => throw new ArgumentException("Unknown description", nameof(description))
        };
#pragma warning restore SYSLIB1045
}