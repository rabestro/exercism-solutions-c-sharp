using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var result = new StringBuilder();

        for (var i = 0; i < identifier.Length; ++i)
        {
            var symbol = identifier[i];

            if (symbol is >= 'α' and <= 'ω')
                continue;
            if (symbol is '-')
                symbol = char.ToUpper(identifier[++i]);
            if (symbol is '\0')
                result.Append("CTRL");
            else if (char.IsWhiteSpace(symbol))
                result.Append('_');
            else if (char.IsLetter(symbol))
                result.Append(symbol);
        }

        return result.ToString();
    }
}
