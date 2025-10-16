public class WeatherStation
{
    private static readonly Reading EmptyReading = new(default, default, default, default);
    private Reading _reading = EmptyReading;
    private readonly List<DateTime> _recordDates = [];
    private readonly List<decimal> _temperatures = [];

    public void AcceptReading(Reading reading)
    {
        _reading = reading;
        _recordDates.Add(DateTime.Now);
        _temperatures.Add(reading.Temperature);
    }

    public void ClearAll()
    {
        _reading = EmptyReading;
        _recordDates.Clear();
        _temperatures.Clear();
    }

    public decimal LatestTemperature => _reading.Temperature;

    public decimal LatestPressure => _reading.Pressure;

    public decimal LatestRainfall => _reading.Rainfall;

    public bool HasHistory => _recordDates.Count > 1;

    public Outlook ShortTermOutlook => _reading.Temperature switch
    {
        _ when _reading == EmptyReading => throw new ArgumentException(),
        < 30m when _reading.Pressure < 10m => Outlook.Cool,
        > 50 => Outlook.Good,
        _ => Outlook.Warm
    };

    public Outlook LongTermOutlook => _reading switch
    {
        { WindDirection: WindDirection.Southerly } => Outlook.Good,
        { WindDirection: WindDirection.Northerly } => Outlook.Cool,
        { WindDirection: WindDirection.Easterly, Temperature: > 20 } => Outlook.Good,
        { WindDirection: WindDirection.Easterly, Temperature: <= 20 } => Outlook.Warm,
        { WindDirection: WindDirection.Westerly } => Outlook.Rainy,
        _ => throw new ArgumentException()
    };

    public State RunSelfTest() => _reading.Equals(EmptyReading) ? State.Bad : State.Good;
}

/*** Please do not modify this struct ***/
public record Reading(decimal Temperature, decimal Pressure,
    decimal Rainfall, WindDirection WindDirection);

/*** Please do not modify this enum ***/
public enum State
{
    Good,
    Bad
}

/*** Please do not modify this enum ***/
public enum Outlook
{
    Cool,
    Rainy,
    Warm,
    Good
}

/*** Please do not modify this enum ***/
public enum WindDirection
{
    Unknown, // default
    Northerly,
    Easterly,
    Southerly,
    Westerly
}