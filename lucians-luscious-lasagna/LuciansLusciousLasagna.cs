using System.Diagnostics.CodeAnalysis;

internal sealed class Lasagna
{
    [SuppressMessage("Performance", "CA1822: Mark members as static")]
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int minutesInOven) => ExpectedMinutesInOven() - minutesInOven;

    [SuppressMessage("Performance", "CA1822: Mark members as static")]
    public int PreparationTimeInMinutes(int numLayers) => numLayers * 2;

    public int ElapsedTimeInMinutes(int numLayers, int minutesInOven) =>
        PreparationTimeInMinutes(numLayers) + minutesInOven;
}