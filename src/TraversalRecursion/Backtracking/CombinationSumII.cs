namespace TraversalRecursion.Backtracking;

public class CombinationSum2
{
    public static List<IList<int>> FindValues(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        if (candidates is null || candidates.Length == 0) return result;

        var a = (int[])candidates.Clone();
        Array.Sort(a); // Sorting is crucial for de-dup

        Backtrack(
            candidates: a,
            remainingTarget: target,
            start: 0,
            currentPath: new List<int>(),
            result: result);

        return result;
    }

    private static void Backtrack(
        int[] candidates,
        int remainingTarget,
        int start,
        List<int> currentPath,
        List<IList<int>> result)
    {
        if (remainingTarget == 0)
        {
            result.Add(new List<int>(currentPath));
            return;
        }

        for (var i = start; i < candidates.Length; i++)
        {
            // Pruning, as before
            if (remainingTarget - candidates[i] < 0)
            {
                break;
            }

            // !!! CHANGE 2: Horizontal de-dup
            if (i > start && candidates[i] == candidates[i - 1])
            {
                continue;
            }

            currentPath.Add(candidates[i]);

            Backtrack(
                candidates: candidates,
                remainingTarget: remainingTarget - candidates[i],
                start: i + 1, // !!! CHANGE 1: Update start with i + 1
                currentPath: currentPath,
                result: result);

            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}