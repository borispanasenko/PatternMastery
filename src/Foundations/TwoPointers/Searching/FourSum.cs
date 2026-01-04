// src/Foundations/TwoPointers/Searching/FourSum.cs
namespace PatternMastery.Foundations.TwoPointers.Searching;

/// <summary>
/// 4-Sum over integers: find unique quadruples (a, b, c, d) such that a + b + c + d == target.
/// Strategy: sort -> fix i -> fix j -> two pointers on (left, right).
/// Time: worst-case O(n^3); Space: O(1) extra (excluding output).
/// Uniqueness via skipping duplicates at every level (i, j, left/right).
/// </summary>
public static class FourSum
{
    /// <summary>
    /// Returns all unique quadruples (in nondecreasing value order) whose sum equals target.
    /// The result contains no duplicate quadruples.
    /// </summary>
    public static List<IList<int>> FindValuesIterative(int[] nums, int target)
    {
        var res = new List<IList<int>>();
        if (nums is null || nums.Length < 4) return res;

        // 1) Sort a copy so we:
        //    - guarantee nondecreasing order inside each quadruple;
        //    - can skip duplicates safely;
        //    - can apply two pointers on the inner layer.
        var a = (int[])nums.Clone();
        Array.Sort(a);

        var n = a.Length;

        // Outer anchor i
        for (var i = 0; i < n - 3; i++)
        {
            // De-dup for i
            if (i > 0 && a[i] == a[i - 1]) continue;

            // Coarse pruning for this i: minimal possible sum and maximal possible sum
            var minSumI = (long)a[i] + a[i + 1] + a[i + 2] + a[i + 3];
            if (minSumI > target) break; // further i will only increase the sum

            var maxSumI = (long)a[i] + a[n - 1] + a[n - 2] + a[n - 3];
            if (maxSumI < target) continue; // this i is too small, try the next i

            // Inner anchor j
            for (var j = i + 1; j < n - 2; j++)
            {
                // De-dup for j (within the same i)
                if (j > i + 1 && a[j] == a[j - 1]) continue;

                // Refined pruning for fixed (i, j)
                var minSumJ = (long)a[i] + a[j] + a[j + 1] + a[j + 2];
                if (minSumJ > target) break; // increasing j will only increase the sum

                var maxSumJ = (long)a[i] + a[j] + a[n - 1] + a[n - 2];
                if (maxSumJ < target) continue; // this j is too small, try next j

                int left = j + 1, right = n - 1;

                // Classic two-pointers layer
                while (left < right)
                {
                    var sum = (long)a[i] + a[j] + a[left] + a[right];

                    if (sum == target)
                    {
                        // In iterative 4-Sum values are simultaneously fixed
                        // and the quadruple is fully determined “in one step”.
                        res.Add(new[] { a[i], a[j], a[left], a[right] });

                        // Skip duplicates on the inner layer (left, right)
                        int lv = a[left], rv = a[right];
                        while (left < right && a[left] == lv) left++;
                        while (left < right && a[right] == rv) right--;
                    }
                    else if (sum < target) left++; else right--;
                }
            }
        }

        return res;
    }


    public static List<IList<int>> FindValuesRecursive(int[] nums, int target)
    {
        var path = new List<int>();
        var res = new List<IList<int>>();

        if (nums is null || nums.Length < 4) return res;

        var a = (int[])nums.Clone();
        Array.Sort(a);
        var n = a.Length;

        DFS(k: 4, a: a, start: 0, end: n - 1, target: target, path: path, res: res);

        return res;
    }

    private static void DFS(
        int k,
        int[] a,
        int start,
        int end,
        long target,
        List<int> path,
        List<IList<int>> res)
    {
        // Main pruning: if less elements than k, then nothing to choose from
        if ((end - start) + 1 < k) return;

        // Partial pruning
        long minSum = 0, maxSum = 0;
        for (var i = 0; i <= k - 1; i++)
        {
            minSum += a[start + i];
            maxSum += a[end - i];
        }

        if (target < minSum || target > maxSum) return;

        if (k == 2)
        {
            int left = start, right = end;

            // Classic two-pointers layer
            while (left < right)
            {
                var sum = (long)a[left] + a[right];

                if (sum == target)
                {
                    // Recursive k-Sum: path already holds (k - 2) elements, now we add the last two
                    var quad = new List<int>(path) { a[left], a[right] };
                    res.Add(quad);

                    // Skip duplicates on the inner layer (left, right)
                    int lv = a[left], rv = a[right];
                    while (left < right && a[left] == lv) left++;
                    while (left < right && a[right] == rv) right--;
                }
                else if (sum < target) left++; else right--;
            }

            return;
        }

        // i_max lefts space for all pointers minus one fixed as i
        var i_max = end - k + 1;
        for (var i = start; i <= i_max; i++)
        {
            // De-dup on i
            if (i > start && a[i] == a[i - 1]) continue;

            path.Add(a[i]);
            DFS(k - 1, a, i + 1, end, target - a[i], path, res);

            // Cleaning the working stack
            path.RemoveAt(path.Count - 1);
        }
    }
}
