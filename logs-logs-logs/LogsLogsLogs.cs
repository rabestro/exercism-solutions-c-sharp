using System;

enum LogLevel
{
    Unknown,
    Trace,
    Debug,
    Info = 4,
    Warning,
    Error,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) =>
        logLine[1] switch
        {
            'T' => LogLevel.Trace,
            'D' => LogLevel.Debug,
            'I' => LogLevel.Info,
            'W' => LogLevel.Warning,
            'E' => LogLevel.Error,
            'F' => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}
