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
          if (checkIfZero(nums)) {return queries.Length;};
            for (int i=0; i<=queries.Length-1; i++){ //loop queries
            var firstBound = queries[i][0];
            var secondBound = queries[i][1];

            int boundLength = Math.Abs(firstBound - secondBound);
            int boundMin = Math.Min(firstBound, secondBound); 
            for (int j = 0; j <= boundLength; j++) { 
                if (nums[boundMin] != 0){  
                    nums[boundMin] = nums[boundMin] - 1;
                };
                boundMin++;
            }
           
            if (checkIfZero(nums)){
                 //return nums[0];
                return queries.Length - (i + 1);
            }
            // int[] sample = retIfZero(nums);
            // return sample[1];
        }
        return -1;
    }
    public bool checkIfZero(int[] nums){
        var n = nums.Length;
        for (int i = 0; i<n; i++){
            if (nums[i] != 0) return false;
        }return true;
    }

    // public int[] retIfZero(int[] nums){
    //     var n = nums.Length;
    //     for (int i = 0; i<n; i++){
    //         if (nums[i] != 0) return nums;
    //     }return nums;
    // }

}