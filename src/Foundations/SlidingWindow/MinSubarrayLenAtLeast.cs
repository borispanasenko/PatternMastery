namespace PatternMastery.Foundations.SlidingWindow;

/// <summary>
/// Minimal length subarray with sum ≥ target (non-negative numbers).
/// State S = (l, r, sum).
/// Invariant: sum = Σ nums[l..r-1].
/// Strategy: expand r → grow sum; shrink l → maintain sum ≥ target.
/// Returns minimal window length; 0 if none.
/// Time: O(n); Space: O(1)
/// </summary>
public static class MinSubarrayLenAtLeast
{
    public static int Find(int target, int[] nums)
    {
        if (nums is null) throw new ArgumentNullException(nameof(nums));
        if (target <= 0) return 0;
        if (nums.Length == 0) return 0;

        int n = nums.Length;
        int minLen = int.MaxValue;
        int l = 0;
        long sum = 0;

        for (int r = 0; r < n; r++)
        {
            sum += nums[r];
            while (sum >= target)
            {
                minLen = Math.Min(minLen, r - l + 1);
                sum -= nums[l++];
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}