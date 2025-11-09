// src/Foundations/TwoPointers/Searching/ThreeSum.cs
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// Finds unique triplets with sum == 0.
/// Two variants:
/// - FindValues: returns triplets of values (deduplicated), O(n^2) time, O(1) extra (excluding output).
/// - FindIndices: returns triplets of original indices whose values sum to 0 (deduped by values).
///   Uses sort of (val, idx) pairs and two-pointers, O(n^2) time, O(n) for the paired array.
/// </summary>
public static class ThreeSum
{
    /// <summary>
    /// Returns unique triplets of VALUES that sum to zero (e.g., [-1, -1, 2], [-1, 0, 1]).
    /// </summary>
    public static List<(int a, int b, int c)> FindValues(int[] nums)
    {
        var res = new List<(int, int, int)>();
        if (nums is null || nums.Length < 3) return res;

        var a = (int[])nums.Clone();
        Array.Sort(a);
        int n = a.Length;

        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && a[i] == a[i - 1]) continue;
            if (a[i] > 0) break; // early exit

            int left = i + 1, right = n - 1;
            while (left < right)
            {
                long sum = (long)a[i] + a[left] + a[right];
                if (sum == 0)
                {
                    res.Add((a[i], a[left], a[right]));
                    int lv = a[left], rv = a[right];
                    while (left < right && a[left] == lv) left++;
                    while (left < right && a[right] == rv) right--;
                }
                else if (sum < 0) left++; else right--;
            }
        }
        return res;
    }


    /// <summary>
    /// Returns unique triplets of ORIGINAL INDICES (i, j, k) such that nums[i] + nums[j] + nums[k] == 0.
    /// Deduplication is by value-combination; multiple index-combos that map to identical values collapse to one.
    /// </summary>
    public static List<(int i, int j, int k)> FindIndices(int[] nums)
    {
        var res = new List<(int, int, int)>();
        if (nums is null || nums.Length < 3) return res;

        var a = new (int val, int idx)[nums.Length];
        for (int t = 0; t < nums.Length; t++)
            a[t] = (nums[t], t);
        Array.Sort(a); // ValueTuple<int,int> lexicographic sorting

        int n = a.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (i > 0 && a[i].val == a[i - 1].val) continue;
            if (a[i].val > 0) break; // early exit

            int left = i + 1, right = n - 1;
            while (left < right)
            {
                long sum = (long)a[i].val + a[left].val + a[right].val;
                if (sum == 0)
                {
                    res.Add((a[i].idx, a[left].idx, a[right].idx));

                    int lv = a[left].val, rv = a[right].val;
                    while (left < right && a[left].val == lv) left++;
                    while (left < right && a[right].val == rv) right--;
                }
                else if (sum < 0) left++; else right--;
            }
        }
        return res;
    }
}
