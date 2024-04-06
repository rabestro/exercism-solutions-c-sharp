using System.Text.RegularExpressions;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        for (
            var previous = "";
            previous != input;
            input = Regex.Replace(input, @"\[]|\{}|\(\)|[^][(){}]", "")
        ) previous = input;
        
        return input.Length == 0;
    }
}