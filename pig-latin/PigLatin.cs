using System.Text.RegularExpressions;

public static class PigLatin
{
    private const string PigLatinFormat = "${base}${consonants}ay";

    private static readonly Regex WordPattern =
        new("""
            (?<consonants>                    # Capture group for possible consonants at the start of a word
                (?!xr|yt)                     # Look ahead negative. Consonants should not start with "xr" or "yt"
                y?                            # Allows optional 'y' at start,
                (qu|[bcdfghjklmnpqrstvwxz])*  # ... then 'qu' or any consonant except 'y'
            )?                                # The entire consonant group is optional (for words starting with vowels)
            (?<base>\w+)                      # Capture group for the base of the word (remaining letters)
            """,
            RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

    public static string Translate(string sentence) =>
        WordPattern.Replace(sentence, PigLatinFormat);
}