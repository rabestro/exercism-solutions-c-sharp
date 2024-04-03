using System;
using System.Collections.Generic;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target == 0) return Array.Empty<int>(); // No coins for 0 change
        if (target < 0) throw new ArgumentException("Negative change not allowed");

        int[] dp = new int[target + 1];
        int[] chosenCoin = new int[target + 1];

        for (int i = 1; i <= target; i++)
        {
            dp[i] = int.MaxValue;
            foreach (int coin in coins)
            {
                if (coin > i) continue;
                if (dp[i - coin] + 1 < dp[i])
                {
                    dp[i] = dp[i - coin] + 1;
                    chosenCoin[i] = coin;
                }
            }
        }

        if (dp[target] == int.MaxValue) throw new ArgumentException("Cannot find a solution");

        List<int> result = new List<int>();
        while (target > 0)
        {
            result.Add(chosenCoin[target]);
            target -= chosenCoin[target];
        }

        return result.ToArray();
    }
}