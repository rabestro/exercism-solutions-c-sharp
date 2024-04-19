using System.Linq;

public static partial class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = word.Where(char.IsLetter).ToArray();
        return letters.Length == letters.DistinctBy(char.ToLower).Count();
    }
}