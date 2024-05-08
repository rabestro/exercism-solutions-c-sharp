using System;
using System.Threading;

public class Robot
{
    private static int _currentId;

    public Robot() => RandomName();

    public string Name { get; private set; }

    public void Reset() => RandomName();

    private void RandomName()
    {
        var random = new Random(Interlocked.Increment(ref _currentId));
        var firstLetter = (char)random.Next('A', 'Z' + 1);
        var secondLetter = (char)random.Next('A', 'Z' + 1);
        var number = random.Next(1000).ToString("D3");
        Name = $"{firstLetter}{secondLetter}{number}";
    }
}