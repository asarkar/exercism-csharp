internal sealed class RemoteControlCar
{
    private int _battery;
    private int _distance;

    public RemoteControlCar()
    {
        _battery = 100;
        _distance = 0;
    }
    public static RemoteControlCar Buy() => new();

    public string DistanceDisplay() => $"Driven {_distance} meters";

    public string BatteryDisplay() => _battery > 0 ? $"Battery at {_battery}%" : "Battery empty";

    public void Drive()
    {
        if (_battery-- > 0)
        {
            _distance += 20;
        }
    }
}