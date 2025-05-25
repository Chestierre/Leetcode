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
    private HashSet<string> visited = new();

    public int MaxRemoval(int[] nums, int[][] queries)
    {
        // Optional: sort queries by size to try more impactful ones early
        Array.Sort(queries, (a, b) => 
            Math.Abs(b[1] - b[0]).CompareTo(Math.Abs(a[1] - a[0])));

        return Backtrack(nums, queries, 0);
    }

    private int Backtrack(int[] nums, int[][] queries, int usedCount)
    {
        if (CheckIfZero(nums)) return queries.Length - usedCount;

        string key = GetKey(nums);
        if (!visited.Add(key)) return -1;

        int maxUnused = -1;

        for (int i = 0; i < queries.Length; i++)
        {
            int a = queries[i][0], b = queries[i][1];
            int minB = Math.Min(a, b), maxB = Math.Max(a, b);

            List<int> changed = new();
            for (int j = minB; j <= maxB; j++)
            {
                if (nums[j] > 0)
                {
                    nums[j]--;
                    changed.Add(j);
                }
            }

            if (changed.Count == 0) continue;

            int res = Backtrack(nums, queries, usedCount + 1);
            if (res != -1)
                maxUnused = Math.Max(maxUnused, res);

            foreach (int j in changed)
                nums[j]++;
        }

        return maxUnused;
    }

    private string GetKey(int[] nums)
    {
        return string.Join(",", nums);
    }

    private bool CheckIfZero(int[] nums)
    {
        foreach (int n in nums)
            if (n != 0) return false;
        return true;
    }
}