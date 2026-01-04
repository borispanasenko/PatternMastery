using System;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class ThreeSumSmallerDemo : IDemo
{
    public string Key   => "three-sum-smaller";
    public string Title => "Foundations / Two Pointers / Searching / ThreeSumSmaller";

    public void Run()
    {
        Program.Header(Title);

        var cases = new (int[] nums, int target)[]
        {
            (new[] { -2, 0, 1, 3 }, 2),        // best < 2: -2+0+3 = 1
            (new[] { 0, 0, 0 }, 1),            // 0+0+0 = 0
            (new[] { 1, 2, 5, 10, 11 }, 12),   // 1+2+5 = 8
            (new[] { -5, 1, 1, 1, 2 }, 0),     // -5+2+1 = -2, -5+1+1 = -3 → best = -2
        };

        foreach (var (nums, target) in cases)
        {
            var sum = ThreeSumSmaller.Find(nums, target);
            Console.WriteLine(
                $"[{string.Join(",", nums)}], target={target} → bestSmaller={sum}");
        }

        // No triplet making sum < target case
        var noSolution = new[] { 5, 6, 7, 8 };
        var noSolutionTarget = 10;

        Console.WriteLine();
        Console.WriteLine("Case with no triplet < target:");

        try
        {
            ThreeSumSmaller.Find(noSolution, noSolutionTarget);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(
                $"[{string.Join(",", noSolution)}], target={noSolutionTarget} → throws: {ex.GetType().Name} ({ex.Message})");
        }
    }
}