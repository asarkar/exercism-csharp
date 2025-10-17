public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum) =>
        shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 & 4 => "center back",
            5 => "right back",
            >= 6 and <= 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            11 => "right wing",
            _ => "UNKNOWN"
        };

    public static string AnalyzeOffField(object report) =>
        report switch
        {
            int numSupporters => $"There are {numSupporters} supporters at the match.",
            string annoucement => annoucement,
            Injury i => $"Oh no! {i.GetDescription()} Medics are on the field.",
            Incident i => i.GetDescription(),
            Manager m => m.Club is null ? m.Name : $"{m.Name} ({m.Club})",
            _ => string.Empty
        };
}