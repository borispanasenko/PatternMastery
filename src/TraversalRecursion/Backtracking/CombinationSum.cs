namespace TraversalRecursion.Backtracking;

public class CombinationSum
{
    public static List<IList<int>> FindValues(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        if (candidates is null || candidates.Length == 0) return result;

        var a = (int[])candidates.Clone();
        Array.Sort(a);

        DFS(
            candidates: a,
            remainingTarget: target,
            start: 0,
            currentPath: new List<int>(),
            result: result);

        return result;
    }

    private static void DFS(
        int[] candidates,
        int remainingTarget,
        int start,
        List<int> currentPath,
        List<IList<int>> result)
    {
        if (remainingTarget < 0)
        {
            return;
        }

        if (remainingTarget == 0)
        {
            result.Add(new List<int>(currentPath));
            return;
        }

        for (var i = start; i < candidates.Length; i++)
        {
            // No sense in deep dive in this case
            if (remainingTarget - candidates[i] < 0)
            {
                break;
            }

            currentPath.Add(candidates[i]);

            DFS(
                candidates: candidates,
                remainingTarget: remainingTarget - candidates[i],
                start: i,
                currentPath: currentPath,
                result: result);

            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}