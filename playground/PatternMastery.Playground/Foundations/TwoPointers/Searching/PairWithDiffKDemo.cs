using PatternMastery.Foundations.TwoPointers.Searching;
namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class PairWithDiffKDemo : IDemo
{
    public string Key => "pair-diff-k";
    public string Title => "Foundations / Two Pointers / Searching / PairWithDifferenceK";

    public void Run()
    {
        var nums = new[] { 7, 1, 5, 9, 2, 12, 3 };
        const int k = 2;

        Program.Header(Title);
        Program.ShowArray("Unsorted", nums);
        var unsorted = PairWithDifferenceK.Find(nums, k);
        Console.WriteLine(unsorted is { } u
            ? $"Unsorted: ({u.left},{u.right}) → ({nums[u.left]},{nums[u.right]})"
            : "Unsorted: not found");

        var sorted = nums.OrderBy(x => x).ToArray();
        Program.ShowArray("Sorted", sorted);
        var sortedRes = PairWithDifferenceKSorted.Find(sorted, k);
        Console.WriteLine(sortedRes is { } s
            ? $"Sorted: ({s.left},{s.right}) → ({sorted[s.left]},{sorted[s.right]})"
            : "Sorted: not found");
    }
}