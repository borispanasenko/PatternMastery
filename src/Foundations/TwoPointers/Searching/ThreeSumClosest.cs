namespace PatternMastery.Foundations.TwoPointers.Searching;

public static class ThreeSumClosest
{
    /// <summary>
    /// Returns the sum of three integers in nums such that the sum is closest to target.
    /// Time: O(n^2), Space: O(1) aside from sort.
    /// </summary>
    /// <returns>int.</returns>
    public static int Find(int[] nums, int target)
    {
        // Precondition, entry threshold
        if (nums is null || nums.Length < 3)
        {
            throw new ArgumentException(
                "Array must contain at least three elements.",
                nameof(nums));
        }

        var a = (int[])nums.Clone();

        // Array-sorted invariant
        Array.Sort(a);
        var n = a.Length;

        var bestSum = (long)a[0] + a[1] + a[2];

        // Current best state monotone non-increasing invariant
        var bestDiff = Math.Abs(bestSum - target);

        for (int i = 0; i < n - 2; i++)
        {
            // De-dup on i
            if (i > 0 && a[i] == a[i - 1]) continue;

            int left = i + 1, right = n - 1;

            // Loop rules/guards
            while (left < right)
            {
                // Current configuration core invariant
                var sum = (long)a[i] + a[left] + a[right];
                if (sum == target) return (int)sum;

                // Invariant distance metric for comparison
                var diff = Math.Abs(sum - target);

                // Invariant-based transition rule/guard
                if (diff < bestDiff)
                {
                    bestDiff = diff;
                    bestSum = sum;
                }

                // pointer-move policy from invariants
                if (sum < target)
                {
                    left++;
                    while (left < right && a[left] == a[left - 1]) left++; 
                }
                else
                {
                    right--;
                    while (left < right && a[right] == a[right + 1]) right--;

                }
            }
        }
        return (int)bestSum;
    }
}