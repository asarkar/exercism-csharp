internal sealed class RemoteControlCar(int speed, int batteryDrain)
{
    private int _distance;
    private int _batteryRemaining = 100;

    public bool BatteryDrained() => _batteryRemaining < batteryDrain;

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distance += speed;
            _batteryRemaining -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

internal sealed class RaceTrack(int distance)
{
    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (car.DistanceDriven() < distance && !car.BatteryDrained())
        {
            car.Drive();
        }
        return car.DistanceDriven() >= distance;
    }
}