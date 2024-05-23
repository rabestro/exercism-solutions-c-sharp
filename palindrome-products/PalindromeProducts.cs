using System;
using System.Collections.Generic;
using System.Linq;

public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        validateFactors(minFactor, maxFactor);
        var largest = int.MinValue;
        var factors = new List<(int, int)>();

        for (int i = maxFactor; i >= minFactor; i--)
        {
            for (int j = i; j >= minFactor; j--)
            {
                var product = i * j;
                if (product < largest) break;
                if (!IsPalindrome(product)) continue;

                if (product > largest)
                {
                    factors = new List<(int, int)>();
                    largest = product;
                }

                factors.Add((j, i));
            }
        }

        if (factors.Count == 0) 
            throw new ArgumentException("No palindrome found");
        return (largest, factors);
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        validateFactors(minFactor, maxFactor);
        var smallest = int.MaxValue;
        var factors = new List<(int, int)>();
        for (int i = minFactor; i <= maxFactor; i++)
        {
            for (int j = i; j <= maxFactor; j++)
            {
                var product = i * j;
                if (product > smallest) break;
                if (!IsPalindrome(product)) continue;

                if (product < smallest)
                {
                    factors = [];
                    smallest = product;
                }

                factors.Add((i, j));
            }
        }
        if (factors.Count == 0) 
            throw new ArgumentException("No palindrome found");
        return (smallest, factors);
    }

    private static void validateFactors(int minFactor, int maxFactor)
    {
        if (minFactor > maxFactor)
            throw new ArgumentException("Incorrect factors");
    }

    private static bool IsPalindrome(int number)
    {
        var numberString = number.ToString();
        return numberString == new string(numberString.Reverse().ToArray());
    }
}