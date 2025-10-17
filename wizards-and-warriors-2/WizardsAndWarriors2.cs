using System.Globalization;

using Microsoft.VisualBasic;

internal static class GameMaster
{
    public static string Describe(Character character) =>
        $"You're a level {character.Level} {character.Class} " +
        $"with {character.HitPoints} hit points.";

    public static string Describe(Destination destination) =>
        $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";

    public static string Describe(TravelMethod travelMethod)
    {
        var preposition = travelMethod == TravelMethod.Horseback ? "on" : "by";
        var method = travelMethod.ToString().ToLower(CultureInfo.InvariantCulture);
        return $"You're traveling to your destination {preposition} {method}.";
    }

    public static string Describe(
        Character character,
        Destination destination,
        TravelMethod travelMethod = TravelMethod.Walking)
    {
        List<string> desc = [Describe(character), Describe(travelMethod), Describe(destination)];
        return string.Join(" ", desc);
    }
}

internal sealed class Character
{
    public string? Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

internal sealed class Destination
{
    public string? Name { get; set; }
    public int Inhabitants { get; set; }
}

internal enum TravelMethod
{
    Walking,
    Horseback
}