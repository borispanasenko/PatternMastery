// Pattern: Two Pointers / Filtering-Partitioning (stable compaction)
// Goal: Move all zeros to the end, keeping the order of non-zeros.
// Time: O(n), Space: O(1)
namespace PatternMastery.Foundations.TwoPointers.FilteringPartitioning;

public static class MoveZeroes
{
    /// <summary>
    /// Moves all zeros to the end of the array, preserving non-zero relative order.
    /// </summary>
    public static void Run(int[] nums)
    {
        if (nums is null || nums.Length == 0) return;

        int write = 0; // position to write next non-zero
        for (int read = 0; read < nums.Length; read++)
        {
            if (nums[read] != 0)
                nums[write++] = nums[read];
        }
        // fill the tail with zeros
        while (write < nums.Length)
            nums[write++] = 0;
    }
}