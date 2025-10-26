using PatternMastery.Foundations.TwoPointers.Searching;
namespace PatternMastery.Playground.Foundations.TwoPointers.Searching;

internal sealed class ThreeSumDemo : IDemo
{
    public string Key => "three-sum";
    public string Title => "Foundations / Two Pointers / Searching / ThreeSum (3Sum)";

    public void Run()
    {
        var nums = new[] { -1, 0, 1, 2, -1, -4 };
        Program.Header(Title);
        Program.ShowArray("Input", nums);

        var values = ThreeSum.FindValues(nums);
        Console.WriteLine("Triplets (values): " +
                          (values.Count == 0 ? "—" :
                              string.Join("; ", values.Select(t => $"({t.a},{t.b},{t.c})"))));

        var indices = ThreeSum.FindIndices(nums);
        Console.WriteLine("Triplets (indices): " +
                          (indices.Count == 0 ? "—" :
                              string.Join("; ", indices.Select(t => $"({t.i},{t.j},{t.k})"))));
    }
}