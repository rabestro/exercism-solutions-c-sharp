using System;

public class Robot
{
    private static int _currentId;

    public Robot() => RandomName(++_currentId);

    public string Name { get; private set; }

    public void Reset() => RandomName(++_currentId);

    private void RandomName(int seed)
    {
        var random = new Random(seed);
        var firstLetter = (char)random.Next('A', 'Z' + 1);
        var secondLetter = (char)random.Next('A', 'Z' + 1);
        var number = random.Next(1000).ToString("D3");
        Name = $"{firstLetter}{secondLetter}{number}";
    }
}