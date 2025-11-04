namespace PatternMastery.Foundations.SlidingWindow;

/// <summary>
/// Maximal length subarray with sum ≤ k (non-negative numbers).
/// State S = (l, r, sum).
/// Invariant: sum = Σ nums[l..r-1] ≤ k.
/// Strategy: expand r while possible, shrink l when sum > k.
/// Returns maximal window length satisfying constraint.
/// Time: O(n); Space: O(1)
/// </summary>
public static class MaxSubarrayLenAtMost
{
    public static int Find(int k, int[] nums)
    {
        if (nums is null) throw new ArgumentNullException(nameof(nums));
        if (k < 0) return 0;
        if (nums.Length == 0) return 0;

        int n = nums.Length;
        int maxLen = 0;
        int l = 0;
        long sum = 0;

        for (int r = 0; r < n; r++)
        {
            sum += nums[r];
            while (sum > k && l <= r)
            {
                sum -= nums[l++];
            }
            if (sum <= k)
                maxLen = Math.Max(maxLen, r - l + 1);
        }

        return maxLen;
    }
}