using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public static decimal Total(IEnumerable<int> books)
    {
        var series = Enumerable.Range(1, 5)
            .Select(i => books.Count(book => book == i))
            .Order()
            .ToArray();

        var groups = Enumerable.Range(0, 5)
            .Select(i => i == 0 ? series[0] : series[i] - series[i - 1])
            .ToArray();

        var combined = Math.Min(groups[2], groups[0]);
        groups[0] -= combined;
        groups[2] -= combined;
        groups[1] += 2 * combined;

        return 8 * (groups[4]
                    + 0.95m * 2 * groups[3]
                    + 0.90m * 3 * groups[2]
                    + 0.80m * 4 * groups[1]
                    + 0.75m * 5 * groups[0]);
    }
}