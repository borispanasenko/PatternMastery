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
        long bArea = 0; int bI = -1, bJ = -1;
        if (heights is null || heights.Length < 2)
            return ((int)bArea, bI, bJ);
        
        int i = 0, j = heights.Length - 1;
        while (i < j)
        {
            // h is the limiting factors / bottleneck
            var h = Math.Min(heights[i], heights[j]);
            // w is getting smaller but the formula stays the same
            var w = (j - i);
            // area is the core invariant
            long area = (long)h * w;
            if (area > bArea) { bArea = area; bI = i; bJ = j; }

            // Move the lower side inward to try for a taller min-height.
            if (heights[i] <= heights[j]) i++; else j--;
        }

        // safe cast: width <= n, height int; fits in int for reasonable n (LeetCode style).
        return ((int)bArea, bI, bJ);
    }
    // Algorithmic reasoning pattern:
    // Preconditions -> Limiting Factor (Bottleneck) -> Core Invariant -> Transition Rule -> Postconditions
}