using System;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class ThreeSumClosestDemo : IDemo
{
    public string Key => "three-sum-closest";
    public string Title => "Foundations / Two Pointers / Searching / ThreeSumClosest";

    public void Run()
    {
        Program.Header(Title);
        var cases = new (int[] nums, int target)[]
        {
            (new[] { -1, 2, 1, -4 }, 1),
            (new[] { 0, 0, 0 }, 1),
            (new[] { 1, 1, 1, 0 }, -100),
            (new[] { 1, 2, 5, 10, 11 }, 12),
        };
        foreach (var (nums, target) in cases)
        {
            var sum = ThreeSumClosest.Find(nums, target);
            Console.WriteLine($"[{string.Join(",", nums)}], target={target} → closest={sum}");
        }
    }
}