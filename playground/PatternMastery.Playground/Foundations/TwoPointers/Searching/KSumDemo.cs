// playground/Foundations/TwoPointers/Searching/KSumDemo.cs
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class KSumDemo : IDemo
{
    public string Key => "k-sum";
    public string Title => "Foundations / Two Pointers / Searching / K-Sum";

    public void Run()
    {
        Program.Header(Title);

        var nums = new[] { 1, 0, -1, 0, -2, 2 };
        Program.ShowArray("nums", nums);

        var k = 4; var target = 0;
        var tuples = KSum.FindValues(nums, k, target);

        Console.WriteLine($"k = {k}, target = {target}");
        if (tuples.Count == 0) { Console.WriteLine("No tuples."); return; }

        foreach (var t in tuples)
            Console.WriteLine($"[{string.Join(", ", t)}]");
    }
}