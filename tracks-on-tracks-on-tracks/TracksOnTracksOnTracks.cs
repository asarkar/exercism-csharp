public static class Languages
{
    public static List<string> NewList() => [];

    public static List<string> GetExistingLanguages() =>
        ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language) =>
        [.. languages, language];

    public static int CountLanguages(List<string> languages) =>
        languages.Count;

    public static bool HasLanguage(List<string> languages, string language) =>
        languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) =>
        [.. languages.AsEnumerable().Reverse()];

    public static bool IsExciting(List<string> languages) =>
        languages switch
        {
            ["C#", ..] => true,
            // when matched.Count is > 1 and < 4 => true,
            var matched and [_, "C#", ..] when matched.Count <= 3 => true,
            _ => false
        };

    public static List<string> RemoveLanguage(List<string> languages, string language) =>
        [.. languages.Where(x => x != language)];

    public static bool IsUnique(List<string> languages) =>
        languages.Distinct().Count() == languages.Count;
}