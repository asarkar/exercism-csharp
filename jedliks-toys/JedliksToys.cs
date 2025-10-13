class RemoteControlCar
{
    private int battery;
    private int distance;

    public RemoteControlCar()
    {
        battery = 100;
        distance = 0;
    }
    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => battery > 0 ? $"Battery at {battery}%" : "Battery empty";

    public void Drive()
    {
        if (battery-- > 0)
        {
            distance += 20;
        }
    }
}
