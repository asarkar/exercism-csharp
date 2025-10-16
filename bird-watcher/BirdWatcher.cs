internal sealed class BirdCount(int[] birdsPerDay)
{
    private readonly int[] _birdsPerDay = birdsPerDay;

    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => _birdsPerDay[^1];

    public void IncrementTodaysCount()
    {
        _birdsPerDay[^1]++;
    }

    public bool HasDayWithoutBirds() => _birdsPerDay.Any(cnt => cnt == 0);

    public int CountForFirstDays(int numberOfDays) => _birdsPerDay[..numberOfDays].Sum();

    public int BusyDays() => _birdsPerDay.Count(cnt => cnt >= 5);
}