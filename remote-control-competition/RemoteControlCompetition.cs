public interface IRemoteControlCar
{
    abstract void Drive();
    int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar? other)
    {
        ArgumentNullException.ThrowIfNull(other);
        return NumberOfVictories.CompareTo(other.NumberOfVictories);
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public override bool Equals(object? obj) =>
        obj is ProductionRemoteControlCar car && CompareTo(car) == 0;


    public override int GetHashCode() => NumberOfVictories.GetHashCode();

    public static bool operator ==(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        left.Equals(right);

    public static bool operator !=(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        !(left == right);

    public static bool operator <(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        left.CompareTo(right) < 0;

    public static bool operator <=(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        left < right || left == right;

    public static bool operator >(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        !(left <= right);

    public static bool operator >=(ProductionRemoteControlCar left, ProductionRemoteControlCar right) =>
        left > right || left == right;
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> cars = [prc1, prc2];
        cars.Sort();
        return cars;
    }
}