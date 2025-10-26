using PatternMastery.HashingLinear.Lookup;
namespace PatternMastery.Playground.HashingLinear.Lookup;

internal sealed class TwoSumUnsortedDemo : IDemo
{
    public string Key => "two-sum-unsorted";
    public string Title => "Hashing & Linear Structures / Lookup / TwoSumUnsorted";

    public void Run()
    {
        var nums = new[] { 7, 2, 5, 3, 11 };
        const int target = 10;

        Program.Header(Title);
        Program.ShowArray("Array", nums);
        Console.WriteLine($"Target: {target}");

        var res = TwoSumUnsorted.Find(nums, target);
        if (res is { } pair)
            Console.WriteLine($"Pair found at ({pair.i}, {pair.j}) → ({nums[pair.i]}, {nums[pair.j]})");
        else
            Console.WriteLine("No pair found");
    }
}