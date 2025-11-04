using System;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Playground.Foundations.SlidingWindow;

internal sealed class MaxSubarrayLenAtMostDemo : IDemo
{
    public string Key => "max-subarray-len-at-most";
    public string Title => "Foundations / Sliding Window / MaxSubarrayLenAtMost";

    public void Run()
    {
        Program.Header(Title);

        var samples = new (int k, int[] nums)[]
        {
            (8,  new[] {2,1,2,2,1}),
            (5,  new[] {1,2,3,1,1}),
            (0,  new[] {1,2,3}),
            (100,new[] {5,5,5,5,5}),
            (10, Array.Empty<int>()),
        };

        foreach (var (k, nums) in samples)
        {
            var res = MaxSubarrayLenAtMost.Find(k, nums);
            Console.WriteLine($"k={k}, nums=[{string.Join(",", nums)}] → maxLen={res}");
        }
    }
}