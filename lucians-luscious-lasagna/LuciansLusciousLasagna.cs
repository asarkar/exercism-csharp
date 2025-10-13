class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int minutesInOven) => ExpectedMinutesInOven() - minutesInOven;

    public int PreparationTimeInMinutes(int numLayers) => numLayers * 2;

    public int ElapsedTimeInMinutes(int numLayers, int minutesInOven) =>
        PreparationTimeInMinutes(numLayers) + minutesInOven;
}
