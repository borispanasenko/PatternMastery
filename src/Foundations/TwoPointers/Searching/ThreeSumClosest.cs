namespace PatternMastery.Foundations.TwoPointers.Searching;

public static class ThreeSumClosest
{
    /// <summary>
    /// Returns the sum of three integers in nums such that the sum is closest to target.
    /// Time: O(n^2), Space: O(1) aside from sort.
    /// </summary>
    public static int Find(int[] nums, int target)
    {
        if (nums is null) throw new ArgumentNullException(nameof(nums));
        if (nums.Length < 3) throw new ArgumentException("Need at least three elements.", nameof(nums));

        Array.Sort(nums);
        int best = nums[0] + nums[1] + nums[2];

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // Optional de-dup on i:
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1, right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (Math.Abs(sum - target) < Math.Abs(best - target))
                    best = sum;

                if (sum == target) return sum;
                if (sum < target)
                {
                    left++;
                    // Optional de-dup on left:
                    while (left < right && nums[left] == nums[left - 1]) left++;
                }
                else
                {
                    right--;
                    // Optional de-dup on right:
                    while (left < right && nums[right] == nums[right + 1]) right--;
                }
            }
        }
        return best;
    }
}