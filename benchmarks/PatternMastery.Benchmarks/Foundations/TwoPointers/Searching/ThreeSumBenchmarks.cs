using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class ThreeSumBenchmarks
{
    private int[] _numsSmall = null!;
    private int[] _numsLarge = null!;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _numsSmall = Enumerable.Range(0, 200).Select(_ => rnd.Next(-50, 50)).ToArray();
        _numsLarge = Enumerable.Range(0, 2000).Select(_ => rnd.Next(-1000, 1000)).ToArray();
    }

    [Benchmark(Baseline = true)]
    public object? SmallArray() => ThreeSum.FindValues(_numsSmall);

    [Benchmark]
    public object? LargeArray() => ThreeSum.FindValues(_numsLarge);
}