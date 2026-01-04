namespace TraversalRecursion.Backtracking;

public class PermutationsII
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var result = new List<IList<int>>();
        var used = new bool[nums.Length];

        var a = (int[])nums.Clone();
        Array.Sort(a);  // Sort to ensure monotonicity

        DFS(a, used, new List<int>(), result);
        return result;
    }

    private void DFS(
        int[] nums,
        bool[] used,
        List<int> currentPath,
        IList<IList<int>> result)
    {
        // 1. BASE: Snake attains the length of initial array
        if (currentPath.Count == nums.Length)
        {
            result.Add(new List<int>(currentPath));
            return;
        }

        // 2. LOOP always starting from 0
        for (var i = 0; i < nums.Length; i++)
        {
            // Skip if number is already used in CURRENT branch.
            if (used[i])
            {
                continue;
            }

            // CHANGE: Intelligent de-dup
            if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
            {
                continue;
            }

            // 3. ACTION
            used[i] = true;        // Mark that "Index i is taken"
            currentPath.Add(nums[i]);

            // 4. RECURSION
            DFS(nums, used, currentPath, result);

            // 5. BACKTRACKING (Rollback changes)
            currentPath.RemoveAt(currentPath.Count - 1);
            used[i] = false;       // IMPORTANT: Mark out the "used" index
        }
    }
}