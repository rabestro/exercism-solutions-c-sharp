using System.Linq;

public static class ScrabbleScore
{
    public static int Score(string input) => input.ToUpper().Select(Score).Sum();

    private static int Score(char letter) =>
        "AEIOULNRST+DG+BCMP+FHVWY+K+JX+QZ".IndexOf(letter) switch
        {
            < 10 => 1,
            < 13 => 2,
            < 18 => 3,
            < 24 => 4,
            < 26 => 5,
            < 29 => 8,
            _ => 10
        };
}