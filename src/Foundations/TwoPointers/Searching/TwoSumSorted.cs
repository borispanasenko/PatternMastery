// <copyright file="TwoSumSorted.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <summary>
// Provides an algorithm for finding two numbers in a sorted array that sum to a given target.
// </summary>
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// Provides an algorithm for finding two numbers in a sorted array that sum to a given target.
/// </summary>
public static class TwoSumSorted
{
    /// <summary>
    /// Finds indices of two elements in a sorted array whose sum equals the specified target.
    /// </summary>
    /// <param name="nums">The sorted array of integers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>
    /// A tuple (i, j) representing the indices of the two elements whose sum equals the target,
    /// or <see langword="null"/> if no such pair exists.
    /// </returns>
    public static (int left, int right)? Find(int[] nums, int target)
    {
        if (nums is null || nums.Length < 2 )
            return null;
        
        int left = 0, right = nums.Length - 1;
        while (left < right)
        {
            var sum = (long)nums[left] + nums[right];
            if (sum == target) return (left, right);
            if (sum < target) left++; else right--;
        }

        return null;
    }
}