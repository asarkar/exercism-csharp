using System.Globalization;

static class Appointment
{
    private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-US");
    public static DateTime Schedule(string appointmentDateDescription) =>
        DateTime.Parse(appointmentDateDescription, Culture);
    // Convert.ToDateTime(appointmentDateDescription)

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var hr = appointmentDate.Hour;
        return hr >= 12 && hr < 18;
    }

    public static string Description(DateTime appointmentDate) =>
        $"You have an appointment on {appointmentDate.ToString("G", Culture)}.";

    public static DateTime AnniversaryDate() => new(DateTime.Now.Year, 9, 15);
}
