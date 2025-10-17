public class RemoteControlCar
{
    // Unlike Java, nested classes in C# do not have an implicit reference to an instance 
    // of the outer class. They are just scoped within the outer class for naming purposes 
    // — not bound to a particular instance.
    // We need to pass the outer instance (Car) into the nested class's constructor or property.
    //
    // 2. Prevent other code taking too many dependencies on the Telemetry type.
    // Check - Only one instance is created per car.
    public RemoteControlCar() => Telemetry = new CarTelemetry(this);
    private Speed _currentSpeed;

    // C#, instance field/property initializers run before the constructor body executes.
    // At that stage, the `this` reference doesn't yet exist.
    public CarTelemetry Telemetry { get; } // = new CarTelemetry(this);

    // Tests call `car.GetSpeed()`, otherwise, we 
    // could've made a `CurrentSpeed` property.
    public string GetSpeed() => _currentSpeed.ToString();
    private void SetSpeed(Speed speed) => _currentSpeed = speed;

    public string? CurrentSponsor { get; private set; }

    public class CarTelemetry(RemoteControlCar car)
    {
        public static void Calibrate()
        {
        }

        public static bool SelfTest() => true;

        public void ShowSponsor(string sponsorName) =>
            car.CurrentSponsor = sponsorName;

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }
            car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    // 4. Prevent other code from taking dependencies on the SpeedUnits enum
    // Check - private.
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    // 3. Prevent other code from taking dependencies on the Speed struct.
    // Check - private.
    private readonly struct Speed(decimal amount, SpeedUnits speedUnits)
    {
        public decimal Amount { get; } = amount;
        public SpeedUnits SpeedUnits { get; } = speedUnits;

        public override string ToString()
        {
            var unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}