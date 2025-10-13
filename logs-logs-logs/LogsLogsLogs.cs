enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    private static readonly Dictionary<string, LogLevel> string2LogLevel = new()
    {
        {"TRC", LogLevel.Trace},
        {"DBG", LogLevel.Debug},
        {"INF", LogLevel.Info},
        {"WRN", LogLevel.Warning},
        {"ERR", LogLevel.Error},
        {"FTL", LogLevel.Fatal}
    };
    public static LogLevel ParseLogLevel(string logLine) =>
        logLine.Length < 4 ? LogLevel.Unknown : string2LogLevel.GetValueOrDefault(logLine[1..4], LogLevel.Unknown);

    public static string OutputForShortLog(LogLevel logLevel, string message) =>
        $"{(int)logLevel}:{message}";
}
