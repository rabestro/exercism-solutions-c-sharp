using System.Linq;

internal class BirdCount(int[] birdsPerDay)
{
    public static int[] LastWeek() => [0, 2, 5, 3, 7, 8, 4];

    public int Today() => birdsPerDay[^1];

    public void IncrementTodaysCount() => ++birdsPerDay[^1];

    public bool HasDayWithoutBirds() => birdsPerDay.Any(x => x == 0);

    public int CountForFirstDays(int numberOfDays) => birdsPerDay[..numberOfDays].Sum();

    public int BusyDays() => birdsPerDay.Count(x => x > 4);
}
