// Pattern: Two Pointers / Filtering-Partitioning (writer/reader)
// Goal: Make each value appear once in a *sorted* array, in-place.
// Return: new logical length (prefix [0..k-1] contains unique values)
// Time: O(n), Space: O(1)
namespace PatternMastery.Foundations.TwoPointers.FilteringPartitioning;

public static class RemoveDuplicatesSorted
{
    /// <summary>
    /// Removes duplicates in-place from a sorted array and returns the new length.
    /// The first 'k' elements of <paramref name="nums"/> are the unique values.
    /// </summary>
    public static int Run(int[] nums)
    {
        if (nums is null || nums.Length == 0) return 0;
        int write = 1; // next free slot for a new unique value
        for (int read = 1; read < nums.Length; read++)
        {
            if (nums[read] != nums[read - 1])
                nums[write++] = nums[read];
        }
        return write;
    }
}