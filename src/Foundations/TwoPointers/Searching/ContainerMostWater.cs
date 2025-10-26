// src/Foundations/TwoPointers/Searching/ContainerMostWater.cs
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// Given non-negative heights, finds the max area formed by two vertical lines (i, j) with width (j - i).
/// Classic two-pointer shrink-from-sides algorithm. O(n) time, O(1) space.
/// </summary>
public static class ContainerMostWater
{
    /// <summary>
    /// Returns (maxArea, i, j) where i &lt; j maximize min(h[i], h[j]) * (j - i).
    /// </summary>
    public static (int area, int i, int j) Find(int[] heights)
    {
        if (heights is null || heights.Length < 2) return (0, -1, -1);

        int i = 0, j = heights.Length - 1;
        long best = 0;
        int bi = -1, bj = -1;

        while (i < j)
        {
            int h = Math.Min(heights[i], heights[j]);
            long area = (long)h * (j - i);
            if (area > best) { best = area; bi = i; bj = j; }

            // Move the lower side inward to try for a taller min-height.
            if (heights[i] <= heights[j]) i++;
            else j--;
        }

        // safe cast: width <= n, height int; fits in int for reasonable n (LeetCode style).
        return ((int)best, bi, bj);
    }
}