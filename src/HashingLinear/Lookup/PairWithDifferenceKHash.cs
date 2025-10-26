// <copyright file="PairWithDifferenceKHash.cs" company="Placeholder">
// Copyright (c) Placeholder. All rights reserved.
// </copyright>

namespace PatternMastery.HashingLinear.Lookup;

/// <summary>
/// Hash-based solution for finding a pair whose absolute difference equals <c>k</c>.
/// Works on an unsorted array and returns original indices.
/// Average Time: O(n); Space: O(n).
/// </summary>
public static class PairWithDifferenceKHash
{
    /// <summary>
    /// Finds indices (i, j) in the original array such that |nums[i] - nums[j]| == k.
    /// If multiple answers exist, returns any one of them.
    /// </summary>
    /// <param name="nums">Input array (unsorted allowed).</param>
    /// <param name="k">Target absolute difference (negative treated as absolute).</param>
    /// <returns>(i, j) with i &lt; j typically (based on streaming order), or null if absent.</returns>
    public static (int i, int j)? Find(int[] nums, int k)
    {
        if (nums is null || nums.Length < 2) return null;
        if (k < 0) k = -k;

        // Map value -> first index where it appeared.
        var firstIndex = new Dictionary<int, int>(capacity: nums.Length);

        // k == 0 needs duplicates of the same value.
        if (k == 0)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var x = nums[i];
                if (firstIndex.TryGetValue(x, out var j))
                    return (j, i);

                firstIndex[x] = i;
            }
            return null;
        }

        // k > 0: as we scan, see if x±k has already appeared.
        for (int i = 0; i < nums.Length; i++)
        {
            var x = nums[i];

            if (firstIndex.TryGetValue(x + k, out var j1))
                return (j1, i);

            if (firstIndex.TryGetValue(x - k, out var j2))
                return (j2, i);

            // record this value if first time seen
            if (!firstIndex.ContainsKey(x))
                firstIndex[x] = i;
        }

        return null;
    }
}
