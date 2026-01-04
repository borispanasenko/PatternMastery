using PatternMastery.Foundations.TwoPointers.Searching;
namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class ThreeSumSmallerCountDemo : IDemo
{
    public string Key   => "three-sum-smaller-count";
    public string Title => "Foundations / Two Pointers / Searching / ThreeSumSmaller (Count)";

    public void Run()
    {
        Program.Header(Title);

        var cases = new (int[] nums, int target)[]
        {
            (new[] { -2, 0, 1, 3 }, 2),
            (new[] { 0, 0, 0 }, 1),
            (new[] { 1, 1, 1, 1 }, 4),
            (new[] { 1, 2, 3, 4, 5 }, 8),
        };

        foreach (var (nums, target) in cases)
        {
            var count = ThreeSumSmallerCount.Count(nums, target);
            Console.WriteLine(
                $"[{string.Join(",", nums)}], target={target} → count={count}");
        }
    }
}