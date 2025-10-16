using Exercism.Tests;

public class NeedForSpeedTests
{
    [Fact]
    [Task(3)]
    public void New_remote_control_car_has_not_driven_any_distance()
    {
        int speed = 10;
        int batteryDrain = 2;
        RemoteControlCar car = new(speed, batteryDrain);

        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact]
    [Task(3)]
    public void Drive_increases_distance_driven_with_speed()
    {
        int speed = 5;
        int batteryDrain = 1;
        RemoteControlCar car = new(speed, batteryDrain);

        car.Drive();

        Assert.Equal(5, car.DistanceDriven());
    }

    [Fact]
    [Task(4)]
    public void Drive_does_not_increase_distance_driven_when_battery_drained()
    {
        int speed = 9;
        int batteryDrain = 50;
        RemoteControlCar car = new(speed, batteryDrain);

        // Drain the battery
        car.Drive();
        car.Drive();

        // One extra drive attempt (should not succeed)
        car.Drive();

        Assert.Equal(18, car.DistanceDriven());
    }

    [Fact]
    [Task(4)]
    public void New_remote_control_car_battery_is_not_drained()
    {
        int speed = 15;
        int batteryDrain = 3;
        RemoteControlCar car = new(speed, batteryDrain);

        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Drive_to_almost_drain_battery()
    {
        int speed = 2;
        int batteryDrain = 1;
        RemoteControlCar car = new(speed, batteryDrain);

        // Almost drain the battery
        for (int i = 0; i < 99; i++)
        {
            car.Drive();
        }

        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Drive_until_battery_is_drained()
    {
        int speed = 2;
        int batteryDrain = 1;
        RemoteControlCar car = new(speed, batteryDrain);

        // Drain the battery
        for (int i = 0; i < 100; i++)
        {
            car.Drive();
        }

        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Super_hungry_car_after_one_drive_is_drained()
    {
        int speed = 100;
        int batteryDrain = 60;
        RemoteControlCar car = new(speed, batteryDrain);
        car.Drive();
        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(4)]
    public void Super_hungry_car_can_try_driving_but_is_drained()
    {
        int speed = 100;
        int batteryDrain = 60;
        RemoteControlCar car = new(speed, batteryDrain);
        car.Drive();
        car.Drive();
        Assert.True(car.BatteryDrained());
        Assert.Equal(100, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_not_driven_any_distance()
    {
        RemoteControlCar car = RemoteControlCar.Nitro();
        Assert.Equal(0, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_battery_not_drained()
    {
        RemoteControlCar car = RemoteControlCar.Nitro();
        Assert.False(car.BatteryDrained());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_correct_speed()
    {
        RemoteControlCar car = RemoteControlCar.Nitro();
        car.Drive();
        Assert.Equal(50, car.DistanceDriven());
    }

    [Fact]
    [Task(5)]
    public void Nitro_car_has_correct_battery_drain()
    {
        RemoteControlCar car = RemoteControlCar.Nitro();

        // The battery is almost drained
        for (int i = 0; i < 24; i++)
        {
            car.Drive();
        }

        Assert.False(car.BatteryDrained());

        // Drain the battery
        car.Drive();

        Assert.True(car.BatteryDrained());
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_can_easily_finish()
    {
        int speed = 10;
        int batteryDrain = 2;
        RemoteControlCar car = new(speed, batteryDrain);

        int distance = 100;
        RaceTrack race = new(distance);

        Assert.True(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_can_just_finish()
    {
        int speed = 2;
        int batteryDrain = 10;
        RemoteControlCar car = new(speed, batteryDrain);

        int distance = 20;
        RaceTrack race = new(distance);

        Assert.True(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_just_cannot_finish()
    {
        int speed = 3;
        int batteryDrain = 20;
        RemoteControlCar car = new(speed, batteryDrain);

        int distance = 16;
        RaceTrack race = new(distance);

        Assert.False(race.TryFinishTrack(car));
    }

    [Fact]
    [Task(6)]
    public void Car_can_finish_with_car_that_cannot_finish()
    {
        int speed = 1;
        int batteryDrain = 20;
        RemoteControlCar car = new(speed, batteryDrain);

        int distance = 678;
        RaceTrack race = new(distance);

        Assert.False(race.TryFinishTrack(car));
    }
}