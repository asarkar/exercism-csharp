class RemoteControlCar(int speed, int batteryDrain)
{
    private int distance;
    private int batteryRemaining = 100;

    public bool BatteryDrained() => batteryRemaining < batteryDrain;

    public int DistanceDriven() => distance;

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distance += speed;
            batteryRemaining -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack(int distance)
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
