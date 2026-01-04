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
    public interface IAnchorHeuristic
    {
        IEnumerable<int> OrderCandidates(int[] a, int start, int k, long target);
    }

    public static List<IList<int>> FindValues(
        int[] nums,
        int k,
        int target,
        IAnchorHeuristic? h = null,
        int? nodeBudget = null)
    {
        var path = new List<int>(k);
        var res = new List<IList<int>>();
        if (nums is null || nums.Length < k || k < 2) return res;

        var a = (int[])nums.Clone();
        Array.Sort(a);

        var n = a.Length;
        const int start = 0;
        var end = n - 1;

        DFS(a, n, start, end, k, target, path, res);
        return res;
    }

    private static void DFS(
        int[] a,
        int n,
        int start,
        int end,
        int k,
        long target,
        List<int> path,
        List<IList<int>> res)
    {
        // Simple pruning
        if (n - start < k) return; // early exit

        // Aggressive pruning, checking extreme limits
        if ((long)a[start] * k > target || (long)a[end] * k < target) return;

        // Precise pruning
        long minSum = 0, maxSum = 0;
        for (var i = 0; i < k; i++) { minSum += a[start + i]; maxSum += a[end - i]; }
        if (target < minSum || target > maxSum) return;


        if (k == 2)
        {
            TwoSum(a, start, end, target, path, res);
            return;
        }

        for (var i = start; i <= end - (k - 1); i++)
        {
            // De-dup on anchor
            if (i > start && a[i] == a[i - 1]) continue; 

            // Refined anchor pruning
            if (a[i] + ((long)a[i + 1] * (k - 1)) > target) break;
            if (a[i] + ((long)a[end] * (k - 1)) < target) continue;

            path.Add(a[i]);
            DFS(a, n, i + 1, end, k - 1, target - a[i], path, res);
            path.RemoveAt(path.Count - 1);
        }
    }

    private static void TwoSum(int[] a, int left, int right, long target, List<int> path, List<IList<int>> res)
    {
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