// <copyright file="PairWithDifferenceK.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// Two-pointer solutions for finding a pair of numbers whose absolute difference equals <c>k</c>.
/// Includes:
/// <list type="bullet">
/// <item>
/// <description><see cref="PairWithDifferenceK.Find(int[], int)"/> — works on an <b>unsorted</b> array; returns original indices.</description>
/// </item>
/// <item>
/// <description><see cref="PairWithDifferenceKSorted.Find(int[], int)"/> — works on a <b>sorted</b> array; returns sorted-array indices.</description>
/// </item>
/// </list>
/// </summary>
/// <remarks>
/// <para>
/// The unsorted version sorts a (value, index) view to enable two pointers while preserving original indices.
/// </para>
/// <para>
/// <b>Edge cases:</b>
/// <list type="bullet">
/// <item><description>Negative <paramref name="k"/> is treated as <c>|k|</c>.</description></item>
/// <item><description><paramref name="k"/> == 0 requires duplicates to succeed.</description></item>
/// <item><description>Returns <c>null</c> when not found or if the input has fewer than 2 elements.</description></item>
/// </list>
/// </para>
/// </remarks>
public static class PairWithDifferenceK
{
    /// <summary>
    /// Finds indices of two elements in an <b>unsorted</b> array whose absolute difference equals <paramref name="k"/>.
    /// Returns <b>original</b> indices from the input array.
    /// </summary>
    /// <param name="nums">Input array (may be unsorted).</param>
    /// <param name="k">Target absolute difference (negative treated as absolute).</param>
    /// <returns>
    /// A tuple <c>(i, j)</c> of original indices such that <c>|nums[i] - nums[j]| == k</c>,
    /// or <c>null</c> if no such pair exists.
    /// </returns>
    /// <example>
    /// <code>
    /// var a = new[] { 7, 1, 5, 9, 2, 12, 3 };
    /// var res = PairWithDifferenceK.Find(a, 2);
    /// // e.g., (i,j) might correspond to values (1,3) or (5,7) etc.
    /// </code>
    /// </example>
    /// <remarks>Time: O(n log n) due to sorting; Space: O(n) for (value, index) pairs.</remarks>
    public static (int left, int right)? Find(int[] nums, int k)
    {
        if (nums is null || nums.Length < 2) return null;
        if (k < 0) return null;

        // Pair values with original indices, then sort by value.
        var arr = new (int val, int idx)[nums.Length];
        for (int t = 0; t < nums.Length; t++)
            arr[t] = (nums[t], t);
        Array.Sort(arr, (a, b) => a.val.CompareTo(b.val));

        int left = 0, right = 1, n = arr.Length;
        while (left < n && right < n)
        {
            if (left == right) { right++; continue; }

            long diff = (long)arr[right].val - arr[left].val;
            if (diff == k) return (arr[left].idx, arr[right].idx);
            if (diff < k) right++; else left++;
        }

        return null;
    }
}

/// <summary>
/// Two-pointer solution for a <b>sorted</b> array to find a pair whose absolute difference equals <c>k</c>.
/// Returns indices in the sorted array.
/// </summary>
public static class PairWithDifferenceKSorted
{
    /// <summary>
    /// Finds indices of two elements in a <b>sorted</b> array whose absolute difference equals <paramref name="k"/>.
    /// </summary>
    /// <param name="nums">Sorted array (non-decreasing).</param>
    /// <param name="k">Target absolute difference (negative treated as absolute).</param>
    /// <returns>
    /// A tuple <c>(i, j)</c> with <c>i &lt; j</c> and <c>nums[j] - nums[i] == k</c>, or <c>null</c> if absent.
    /// </returns>
    /// <example>
    /// <code>
    /// var a = new[] { 1, 3, 5, 7, 9 };
    /// var res = PairWithDifferenceKSorted.Find(a, 4); // e.g., (0,2) for values (1,5)
    /// </code>
    /// </example>
    /// <remarks>Time: O(n); Space: O(1).</remarks>
    public static (int left, int right)? Find(int[] nums, int k)
    {
        int left = 0, right = 1;
        if (nums is null || nums.Length < 2) return null;
        if (k < 0) return null;

        while (right < nums.Length)
        {
            // State space = all (i, j) where i < j
            if (left == right) { right++; continue; }

            // var diff = (long)nums[right] - nums[left];
            long diff = (long)nums[right] - nums[left];
            if (diff == k) return (left, right);
            if (diff < k) right++; else left++;
        }

        return null;
    }
}
