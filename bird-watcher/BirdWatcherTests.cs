using Exercism.Tests;

public class BirdWatcherTests
{
    [Fact]
    [Task(1)]
    public void Last_week()
    {
        Assert.Equal([0, 2, 5, 3, 7, 8, 4], BirdCount.LastWeek());
    }

    [Fact]
    [Task(2)]
    public void Today_for_disappointing_day()
    {
        int[] counts = [0, 0, 1, 0, 0, 1, 0];
        BirdCount birdCount = new(counts);
        Assert.Equal(0, birdCount.Today());
    }

    [Fact]
    [Task(2)]
    public void Today_for_busy_day()
    {
        int[] counts = [8, 8, 9, 5, 4, 7, 10];
        BirdCount birdCount = new(counts);
        Assert.Equal(10, birdCount.Today());
    }

    [Fact]
    [Task(3)]
    public void Increment_todays_count_with_no_previous_visits()
    {
        int[] counts = [0, 0, 0, 4, 2, 3, 0];
        BirdCount birdCount = new(counts);
        birdCount.IncrementTodaysCount();
        Assert.Equal(1, birdCount.Today());
    }

    [Fact]
    [Task(3)]
    public void Increment_todays_count_with_multiple_previous_visits()
    {
        int[] counts = [8, 8, 9, 2, 1, 6, 4];
        BirdCount birdCount = new(counts);
        birdCount.IncrementTodaysCount();
        Assert.Equal(5, birdCount.Today());
    }

    [Fact]
    [Task(4)]
    public void Has_day_without_birds_with_day_without_birds()
    {
        int[] counts = [5, 5, 4, 0, 7, 6, 7];
        BirdCount birdCount = new(counts);
        Assert.True(birdCount.HasDayWithoutBirds());
    }

    [Fact]
    [Task(4)]
    public void Has_day_without_birds_with_no_day_without_birds()
    {
        int[] counts = [4, 5, 9, 10, 9, 4, 3];
        BirdCount birdCount = new(counts);
        Assert.False(birdCount.HasDayWithoutBirds());
    }

    [Fact]
    [Task(5)]
    public void Count_for_first_three_days_of_disappointing_week()
    {
        int[] counts = [0, 0, 1, 0, 0, 1, 0];
        BirdCount birdCount = new(counts);
        Assert.Equal(1, birdCount.CountForFirstDays(3));
    }

    [Fact]
    [Task(5)]
    public void Count_for_first_six_days_of_busy_week()
    {
        int[] counts = [5, 9, 12, 6, 8, 8, 17];
        BirdCount birdCount = new(counts);
        Assert.Equal(48, birdCount.CountForFirstDays(6));
    }

    [Fact]
    [Task(6)]
    public void Busy_days_for_disappointing_week()
    {
        int[] counts = [1, 1, 1, 0, 0, 0, 0];
        BirdCount birdCount = new(counts);
        Assert.Equal(0, birdCount.BusyDays());
    }

    [Fact]
    [Task(6)]
    public void Busy_days_for_busy_week()
    {
        int[] counts = [4, 9, 5, 7, 8, 8, 2];
        BirdCount birdCount = new(counts);
        Assert.Equal(5, birdCount.BusyDays());
    }
}