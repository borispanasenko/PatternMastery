namespace PatternMastery.Foundations.TwoPointers.Searching;
using System.Collections.Generic;

class TwoSumAll
{
    static List<(int, int)> FindTwoPointers(int[] nums, int target)
    {
        Array.Sort(nums);
        var res = new List<(int, int)>();

        int left = 0, right = nums.Length - 1;

        while (left < right)
        {
            var sum = (long)nums[left] + nums[right];

            if (sum == target)
            {
                res.Add((nums[left], nums[right]));

                // De-dup on left and right
                var lv = nums[left];
                while (left < right && nums[left] == lv) left++;

                var rv = nums[right];
                while (left < right && nums[right] == rv) right--;
            }
            else if (sum < target) left++; else right--;
        }

        return res;
    }

    static List<(int, int)> FindHashSet(int[] nums, int target)
    {
        var seen = new HashSet<int>();
        var pairs = new HashSet<(int, int)>();

        foreach (var num in nums)
        {
            var complement = target - num;

            if (seen.Contains(complement))
            {
                var pair = (Math.Min(num, complement), Math.Max(num, complement));
                pairs.Add(pair);
            }

            seen.Add(num);
        }

        var res = new List<(int, int)>(pairs);
        return res;
    }
}
