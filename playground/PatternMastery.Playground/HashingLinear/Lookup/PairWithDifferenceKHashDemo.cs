using PatternMastery.HashingLinear.Lookup;

namespace PatternMastery.Playground.HashingLinear.Lookup;

internal sealed class PairWithDifferenceKHashDemo : IDemo
{
    public string Key => "pair-diff-k-hash";
    public string Title => "Hashing / Lookup / PairWithDifferenceK (Hash)";

    public void Run()
    {
        var examples = new[]
        {
            new { Nums = new[] { 7, 1, 5, 9, 2, 12, 3 }, K = 2 },
            new { Nums = new[] { 1, 4, 8, 13 }, K = 3 },
            new { Nums = new[] { 3, 8, 3, 10 }, K = 0 },
            new { Nums = new[] { 2, 9, 4 }, K = -5 }
        };

        Program.Header(Title);
        foreach (var e in examples)
        {
            Program.ShowArray("Array", e.Nums);
            Console.WriteLine($"k = {e.K}");

            var result = PairWithDifferenceKHash.Find(e.Nums, e.K);
            if (result is { } pair)
            {
                var (i, j) = pair;
                Console.WriteLine($"Found: nums[{i}]={e.Nums[i]}, nums[{j}]={e.Nums[j]} (|diff|={Math.Abs(e.Nums[i] - e.Nums[j])})");
            }
            else
            {
                Console.WriteLine("No pair found.");
            }

            Console.WriteLine();
        }
    }
}