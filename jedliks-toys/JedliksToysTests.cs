using Exercism.Tests;

public class JedliksToysTests
{
    [Fact]
    [Task(1)]
    public void Buy_new_car_returns_instance()
    {
        RemoteControlCar car = RemoteControlCar.Buy();
        Assert.NotNull(car);
    }

    [Fact]
    [Task(1)]
    public void Buy_new_car_returns_new_car_each_time()
    {
        RemoteControlCar car1 = RemoteControlCar.Buy();
        RemoteControlCar car2 = RemoteControlCar.Buy();
        Assert.NotSame(car2, car1);
    }

    [Fact]
    [Task(2)]
    public void New_car_distance_display()
    {
        RemoteControlCar car = new();
        Assert.Equal("Driven 0 meters", car.DistanceDisplay());
    }

    [Fact]
    [Task(3)]
    public void New_car_battery_display()
    {
        RemoteControlCar car = new();
        Assert.Equal("Battery at 100%", car.BatteryDisplay());
    }

    [Fact]
    [Task(4)]
    public void Distance_display_after_driving_once()
    {
        RemoteControlCar car = new();
        car.Drive();
        Assert.Equal("Driven 20 meters", car.DistanceDisplay());
    }

    [Fact]
    [Task(4)]
    public void Distance_display_after_driving_multiple_times()
    {
        RemoteControlCar car = new();

        for (int i = 0; i < 17; i++)
        {
            car.Drive();
        }

        Assert.Equal("Driven 340 meters", car.DistanceDisplay());
    }

    [Fact]
    [Task(5)]
    public void Battery_display_after_driving_once()
    {
        RemoteControlCar car = new();
        car.Drive();
        Assert.Equal("Battery at 99%", car.BatteryDisplay());
    }

    [Fact]
    [Task(5)]
    public void Battery_display_after_driving_multiple_times()
    {
        RemoteControlCar car = new();

        for (int i = 0; i < 23; i++)
        {
            car.Drive();
        }

        Assert.Equal("Battery at 77%", car.BatteryDisplay());
    }

    [Fact]
    [Task(6)]
    public void Battery_display_when_battery_empty()
    {
        RemoteControlCar car = new();

        // Drain the battery
        for (int i = 0; i < 100; i++)
        {
            car.Drive();
        }

        // Attempt to drive one more time (should not work)
        car.Drive();

        Assert.Equal("Battery empty", car.BatteryDisplay());
    }

    [Fact]
    [Task(6)]
    public void Distance_display_when_battery_empty()
    {
        RemoteControlCar car = new();

        // Drain the battery
        for (int i = 0; i < 100; i++)
        {
            car.Drive();
        }

        // Attempt to drive one more time (should not work)
        car.Drive();

        Assert.Equal("Driven 2000 meters", car.DistanceDisplay());
    }
}