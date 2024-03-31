using System;

public class Player
{
    private const int DiceSides = 18;
    private const double MaxStrength = 100;
    private readonly Random _random = new();
    public int RollDie() => 1 + _random.Next(DiceSides);

    public double GenerateSpellStrength() => MaxStrength * _random.NextDouble();
}
