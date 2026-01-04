namespace PatternMastery.Foundations.TwoPointers.Searching;

public static class ThreeSumSmallerCount
{
    /// <summary>
    /// Returns the number of triplets (i, j, k) with i &lt; j &lt; k
    /// such that nums[i] + nums[j] + nums[k] &lt; target.
    /// Time: O(n^2), Space: O(1) aside from sort.
    /// </summary>
    public static int Count(int[] nums, int target)
    {
        if (nums is null || nums.Length < 3)
        {
            throw new ArgumentException(
                "Array must contain at least three elements.",
                nameof(nums));
        }

        var a = (int[])nums.Clone();
        Array.Sort(a);
        var n = a.Length;

        long count = 0; // use long just in case, change to int on return

        for (var i = 0; i < n - 2; i++)
        {
            int left = i + 1, right = n - 1;

            while (left < right)
            {
                var sum = (long)a[i] + a[left] + a[right];

                if (sum < target)
                {
                    // Key trick:
                    // a[i] is fixed, a[left] is fixed,
                    // array is sorted, so:
                    // for all t in [left+1, right]
                    // sum(i, left, t) <= sum(i, left, right) < target.
                    // → add all triplets: (i, left, left..right)
                    count += right - left;
                    left++;
                }
                else
                {
                    // sum >= target → decrease sum
                    right--;
                }
            }
        }

        return (int)count;
    }
}