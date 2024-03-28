using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string message, string delimiter)
    {
        return message.Split(delimiter, 2)[1];
    }

    public static string SubstringBetween(this string message, string prefix, string suffix)
    {
        return message.SubstringAfter(prefix).Split(suffix)[0];
    }
    
    public static string Message(this string message)
    {
        return message.SubstringAfter(": ");
    }

    public static string LogLevel(this string message)
    {
        return message.SubstringBetween("[", "]");
    }
}