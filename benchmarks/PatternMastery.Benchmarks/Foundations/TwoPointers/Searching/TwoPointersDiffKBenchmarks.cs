using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class TwoPointersDiffKBenchmarks
{
    private int[] _unsorted = default!;
    private int[] _sorted = default!;
    private const int K = 50_000;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _unsorted = Enumerable.Range(0, 200_000).Select(_ => rnd.Next()).ToArray();
        _sorted = _unsorted.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public (int left, int right)? TwoPointers_Unsorted()
        => PairWithDifferenceK.Find(_unsorted, K);

    [Benchmark]
    public (int left, int right)? TwoPointers_Sorted()
        => PairWithDifferenceKSorted.Find(_sorted, K);
}