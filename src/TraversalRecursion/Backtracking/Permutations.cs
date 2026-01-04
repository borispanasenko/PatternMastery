namespace TraversalRecursion.Backtracking;

public class Permutations
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();

        // Memory: false by default
        var used = new bool[nums.Length];

        DFS(nums, used, new List<int>(), result);
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