using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Sample test
        // int[] nums = { 1, 1, 1, 1 };
        int[] nums = { 0, 3, 5, 5, 1, 4, 4 };

        int[][] queries = new int[][] {
            // new int[] { 1, 3 },
            // new int[] { 0, 2 },
            // new int[] { 1, 3 },
            // new int[] { 1, 2 }

            new int[] { 1, 4 },
            new int[] { 0, 1 },
            new int[] { 4, 5 },
            new int[] { 3, 4 },
            new int[] { 1, 5 },
            new int[] { 0, 1 },
            new int[] { 0, 3 },
            new int[] { 2, 6 },
            new int[] { 4, 5 },
            new int[] { 1, 3 },
            new int[] { 1, 2 },
            new int[] { 4, 4 },
            new int[] { 4, 6 },
            new int[] { 4, 6 },
            new int[] { 4, 5 },
            new int[] { 2, 3 },
            new int[] { 0, 5 },
            new int[] { 0, 3 },
            new int[] { 2, 4 },
            new int[] { 3, 5 }
        };

        Solution sol = new Solution();
        int result = sol.MaxRemoval(nums, queries);

        Console.WriteLine("Max Removal: " + result);
    }
}


public class Solution
{
    public int MaxRemoval(int[] nums, int[][] queries)
    {
        int result = Backtrack(nums, queries, new bool[queries.Length], 0);
        return result == int.MaxValue ? -1 : result;
    }

    public int Backtrack(int[] nums, int[][] queries, bool[] used, int usedCount)
    {
        if (CheckIfZero(nums))
        {
            Console.WriteLine("[{0}]", string.Join(", ", used));
            Console.WriteLine("Reached zero state. Queries left unused: " + (usedCount));
            return queries.Length - usedCount;
        }

        int minUsed = -1;

        for (int i = 0; i < queries.Length; i++)
        {
            if (used[i]) continue;

            int a = queries[i][0];
            int b = queries[i][1];
            int minB = Math.Min(a, b);
            int maxB = Math.Max(a, b);

            bool anyChange = false;
            // for (int j = minB; j <= maxB; j++)
            // {
            //     if (nums[j] > 0)
            //     {
            //         anyChange = true;
            //         break;
            //     }
            // }


            int[] numsCopy = (int[])nums.Clone();
            for (int j = minB; j <= maxB; j++)
            {
                if (numsCopy[j] > 0) {
                    numsCopy[j]--;
                    anyChange = true;
                }
                
            }
            if (!anyChange) continue;

            used[i] = true;
            int result = Backtrack(numsCopy, queries, used, usedCount + 1);
            if (result != int.MaxValue)
            {
                minUsed = Math.Max(minUsed, result);
            }
            used[i] = false;
        }

        return minUsed;
    }

    public bool CheckIfZero(int[] nums)
    {
        foreach (int n in nums)
        {
            if (n != 0) return false;
        }
        return true;
    }
}

