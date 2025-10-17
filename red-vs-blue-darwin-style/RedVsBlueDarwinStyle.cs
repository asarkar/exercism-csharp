#pragma warning disable IDE0130, CS9113
namespace RedRemoteControlCarTeam
{
    public class RemoteControlCar(
        Motor motor,
        Chassis chassis,
        Telemetry telemetry,
        RunningGear runningGear)
    {
        // red members and API
    }

    public class RunningGear
    {
        // red members and API
    }

    public class Telemetry
    {
        // red members and API
    }

    public class Chassis
    {
        // red members and API
    }

    public class Motor
    {
        // red members and API
    }
}

namespace BlueRemoteControlCarTeam
{
    public class RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry)
    {
        // blue members and API
    }

    public class Telemetry
    {
        // blue members and API
    }

    public class Chassis
    {
        // blue members and API
    }

    public class Motor
    {
        // blue members and API
    }
}

namespace Combined
{
#pragma warning disable IDE0065
    using Blue = BlueRemoteControlCarTeam;
    using Red = RedRemoteControlCarTeam;
#pragma warning restore IDE0065
    public static class CarBuilder
    {
        public static Red.RemoteControlCar BuildRed() =>
            new(
                new(),
                new(),
                new(),
                new()
            );

        public static Blue.RemoteControlCar BuildBlue() =>
            new(
                new(),
                new(),
                new()
            );
    }
}
#pragma warning restore IDE0130, CS9113