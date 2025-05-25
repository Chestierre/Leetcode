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

public class Solution {
    public int MaxRemoval(int[] nums, int[][] queries) {
        int[] numsCopy = (int[])nums.Clone();
        int result = RecursiveCheck(numsCopy, queries, new bool[queries.Length], 0);
        return result;
    }

     public int RecursiveCheck(int[] nums, int[][] queries, bool[] used, int usedCount) {
        if (CheckIfZero(nums)) return queries.Length - usedCount;

        int[] weight = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++) {
            if (used[i]) continue;

            int[] test = (int[])nums.Clone();
            int matches = 0;

            int firstBound = queries[i][0];
            int secondBound = queries[i][1];

            int minBound = Math.Min(firstBound, secondBound);
            int maxBound = Math.Max(firstBound, secondBound);

            for (int j = minBound; j <= maxBound; j++) {
                if (test[j] > 0) {
                    matches++;
                    test[j]--;
                }
            }

            weight[i] = matches;
        }

        // Find the best query to apply next
        int maxIndex = -1;
        int maxValue = 0;
        for (int i = 0; i < weight.Length; i++) {
            if (!used[i] && weight[i] > maxValue) {
                maxValue = weight[i];
                maxIndex = i;
            }
        }

        if (maxIndex == -1) return -1;

        // Apply the best query to the original nums
        int a = queries[maxIndex][0];
        int b = queries[maxIndex][1];
        int minB = Math.Min(a, b);
        int maxB = Math.Max(a, b);
        for (int j = minB; j <= maxB; j++) {
            if (nums[j] > 0) nums[j]--;
        }

        used[maxIndex] = true;

        return RecursiveCheck(nums, queries, used, usedCount + 1);
    }

    public bool CheckIfZero(int[] nums) {
        foreach (int n in nums) {
            if (n != 0) return false;
        }
        return true;
    }

}