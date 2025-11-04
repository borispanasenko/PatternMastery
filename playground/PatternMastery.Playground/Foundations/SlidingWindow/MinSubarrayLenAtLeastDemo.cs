using System;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Playground.Foundations.SlidingWindow;

internal sealed class MinSubarrayLenAtLeastDemo : IDemo
{
    public string Key => "min-subarray-len-at-least";
    public string Title => "Foundations / Sliding Window / MinSubarrayLenAtLeast";

    public void Run()
    {
        Program.Header(Title);

        var samples = new (int target, int[] nums)[]
        {
            (7,  new[] {2,3,1,2,4,3}),
            (4,  new[] {1,4,4}),
            (11, new[] {1,1,1,1,1,1,1}),
            (5,  new[] {5}),
            (1,  Array.Empty<int>()),
        };

        foreach (var (target, nums) in samples)
        {
            var res = MinSubarrayLenAtLeast.Find(target, nums);
            Console.WriteLine($"target={target}, nums=[{string.Join(",", nums)}] → minLen={res}");
        }
    }
}