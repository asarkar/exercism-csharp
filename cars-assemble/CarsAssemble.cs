internal static class AssemblyLine
{
    private const int HourlyProductionRate = 221;
    public static double SuccessRate(int speed) =>
        speed switch
        {
            0 => 0.0,
            < 5 => 1.0,
            < 9 => 0.9,
            9 => 0.8,
            _ => 0.77
        };


    public static double ProductionRatePerHour(int speed) =>
        HourlyProductionRate * speed * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>
        (int)(ProductionRatePerHour(speed) / 60);
}