namespace PatternMastery.Foundations.TwoPointers.Searching;

public static class ThreeSumSmaller
{
    /// <summary>
    /// Returns the sum of three integers in nums such that the sum is smaller than target.
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

        long? bestSum = null;

        for (var i = 0; i < n - 2; i++)
        {
            // De-dup on i
            if (i > 0 && a[i] == a[i - 1]) continue;

            int left = i + 1, right = n - 1;

            // Loop rules/guards
            while (left < right)
            {
                // Current configuration core invariant
                var sum = (long)a[i] + a[left] + a[right];

                // pointer-move policy from invariants
                if (sum < target)
                {
                    if (bestSum is null || sum > bestSum.Value)
                    {
                        bestSum = sum;
                    }

                    left++;
                    while (left < right && a[left] == a[left - 1]) left++; 
                }

                // if (sum >= target)
                else
                {
                    right--;
                    while (left < right && a[right] == a[right + 1]) right--;
                }
            }
        }

        if (bestSum is null)
        {
            throw new InvalidOperationException(
                "No triplet with sum smaller than target was found.");
        }

        return (int)bestSum;
    }
}