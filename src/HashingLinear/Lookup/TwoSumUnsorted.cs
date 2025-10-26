namespace PatternMastery.HashingLinear.Lookup;

/// <summary>
/// Finds two distinct elements in an unsorted array whose sum equals a given target.
/// Uses a hash map for O(n) lookup time.
/// </summary>
public static class TwoSumUnsorted
{
    /// <summary>
    /// Finds indices of two numbers in an unsorted array that sum to a target.
    /// </summary>
    /// <param name="nums">Input array of integers (unsorted).</param>
    /// <param name="target">Target sum to find.</param>
    /// <returns>
    /// A tuple (i, j) of indices such that nums[i] + nums[j] == target,
    /// or null if no pair exists.
    /// </returns>
    /// <remarks>
    /// Time complexity: O(n).  
    /// Space complexity: O(n).  
    /// Uses a dictionary mapping value → index.
    /// </remarks>
    public static (int i, int j)? Find(int[] nums, int target)
    {
        if (nums is null || nums.Length < 2)
            return null;

        var seen = new Dictionary<int, int>(); // value → index

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (seen.TryGetValue(complement, out int j))
                return (j, i);

            // store only first occurrence to preserve deterministic indices
            if (!seen.ContainsKey(nums[i]))
                seen[nums[i]] = i;
        }

        return null;
    }
}