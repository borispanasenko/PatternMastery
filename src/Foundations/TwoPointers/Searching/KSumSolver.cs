// src/Foundations/TwoPointers/Searching/KSum.cs
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// General K-Sum over integers: find unique K-tuples of VALUES that sum to target.
/// Strategy: sort -> fix anchor -> recurse to (k-1)-sum -> bottom out at 2-sum (two pointers).
/// Time: worst-case ~ O(n^(k-1)); Space: O(k) recursion + output.
/// Uniqueness via skipping equal anchors and equal pair-values at each depth.
/// </summary>
public static class KSum
{
    /// <summary>
    /// Returns unique K-tuples (as int[] of length k) whose VALUES sum to target.
    /// Tuples are in nondecreasing value order; result has no duplicates.
    /// </summary>
    public static List<IList<int>> FindValues(int[] nums, int k, int target)
    {
        var res = new List<IList<int>>();
        if (nums is null || k < 2 || nums.Length < k) return res;

        var a = (int[])nums.Clone();
        Array.Sort(a);

        DFS(a, start: 0, k: k, target: target, path: new List<int>(k), res);
        return res;
    }

    private static void DFS(int[] a, int start, int k, long target, List<int> path, List<IList<int>> res)
    {
        int n = a.Length;

        // Simple pruning via min/max possible sums at this depth
        if (start >= n) return;
        long minSum = 0; for (int i = 0; i < k; i++) { int idx = start + i; if (idx >= n) return; minSum += a[idx]; }
        long maxSum = 0; for (int i = 0; i < k; i++) { int idx = n - 1 - i; if (idx < start) return; maxSum += a[idx]; }
        if (target < minSum || target > maxSum) return;

        if (k == 2)
        {
            TwoSum(a, start, target, path, res);
            return;
        }

        for (int i = start; i <= n - k; i++)
        {
            if (i > start && a[i] == a[i - 1]) continue; // skip duplicate anchors

            path.Add(a[i]);
            DFS(a, i + 1, k - 1, target - a[i], path, res);
            path.RemoveAt(path.Count - 1);
        }
    }

    private static void TwoSum(int[] a, int left, long target, List<int> path, List<IList<int>> res)
    {
        int right = a.Length - 1;
        while (left < right)
        {
            long sum = (long)a[left] + a[right];
            if (sum == target)
            {
                var combo = new List<int>(path.Count + 2);
                combo.AddRange(path);
                combo.Add(a[left]);
                combo.Add(a[right]);
                res.Add(combo);

                int lv = a[left], rv = a[right];
                while (left < right && a[left] == lv) left++;
                while (left < right && a[right] == rv) right--;
            }
            else if (sum < target) left++; else right--;
        }
    }
}