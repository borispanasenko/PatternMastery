using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Benchmarks.Foundations.SlidingWindow;

[MemoryDiagnoser]
public class MinSubarrayLenAtLeastBenchmarks
{
    private int[] _small = default!;
    private int[] _large = default!;

    [Params(50, 500, 5_000)]
    public int Target { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _small = Enumerable.Range(0, 10_000).Select(_ => rnd.Next(0, 10)).ToArray();
        _large = Enumerable.Range(0, 1_000_000).Select(_ => rnd.Next(0, 10)).ToArray();
    }

    [Benchmark]
    public int Small_Find() => MinSubarrayLenAtLeast.Find(Target, _small);

    [Benchmark]
    public int Large_Find() => MinSubarrayLenAtLeast.Find(Target * 50, _large);
}