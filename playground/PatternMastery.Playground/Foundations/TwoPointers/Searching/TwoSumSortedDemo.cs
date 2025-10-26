using PatternMastery.Foundations.TwoPointers.Searching;
namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class TwoSumSortedDemo : IDemo
{
    public string Key => "two-sum-sorted";
    public string Title => "Foundations / Two Pointers / Searching / TwoSumSorted";

    public void Run()
    {
        var nums = new[] { 1, 2, 3, 4, 6 };
        const int target = 6;
        var res = TwoSumSorted.Find(nums, target);

        Program.Header(Title);
        Program.ShowArray("Array", nums);
        Console.WriteLine($"Target: {target}");
        if (res is { } pair)
            Console.WriteLine($"Pair at ({pair.left},{pair.right}) → ({nums[pair.left]},{nums[pair.right]})");
        else
            Console.WriteLine("Not found");
    }
}