// Pattern: Two Pointers / Partitioning (three-way partition)
// Goal: Partition array containing only {0,1,2} into 0s, then 1s, then 2s.
// Time: O(n), Space: O(1)
namespace PatternMastery.Foundations.TwoPointers.FilteringPartitioning;

public static class DutchNationalFlag
{
    /// <summary>
    /// In-place 3-way partition for values {0,1,2} using low/mid/high pointers.
    /// </summary>
    public static void Sort012(int[] nums)
    {
        if (nums is null || nums.Length <= 1) return;

        int low = 0, mid = 0, high = nums.Length - 1;
        while (mid <= high)
        {
            switch (nums[mid])
            {
                case 0:
                    (nums[low], nums[mid]) = (nums[mid], nums[low]);
                    low++; mid++;
                    break;
                case 1:
                    mid++;
                    break;
                case 2:
                    (nums[mid], nums[high]) = (nums[high], nums[mid]);
                    high--;
                    break;
                default:
                    // If you want, throw; but many LC-style problems guarantee 0/1/2 only.
                    mid++;
                    break;
            }
        }
    }
}