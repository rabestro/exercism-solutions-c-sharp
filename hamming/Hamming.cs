using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("The strands must be the same length.");
        }
        return firstStrand.Where((t, i) => t != secondStrand[i]).Count();
    }
}