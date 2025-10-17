using System.Diagnostics.CodeAnalysis;

public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDrivenInMeters;
    private string[] _sponsors = [];
    private int _latestSerialNum;

    public void Drive()
    {
        if (_batteryPercentage > 0)
        {
            _batteryPercentage -= 10;
            _distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors) =>
        _sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) =>
        _sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        var validSerialNum = serialNum >= _latestSerialNum;
        if (validSerialNum)
        {
            batteryPercentage = _batteryPercentage;
            distanceDrivenInMeters = _distanceDrivenInMeters;
            _latestSerialNum = serialNum;
        }
        else
        {
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            serialNum = _latestSerialNum;
        }
        return validSerialNum;
    }

    public static RemoteControlCar Buy() => new();
}

public class TelemetryClient(RemoteControlCar car)
{
    [SuppressMessage("Style", "IDE0046: Use conditional expression for return")]
    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (
            car.GetTelemetryData(
                ref serialNum,
                out var batteryPercentage,
                out var distanceDrivenInMeters
                ) && distanceDrivenInMeters > 0)
        {
            return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
        }
        return "no data";
    }
}