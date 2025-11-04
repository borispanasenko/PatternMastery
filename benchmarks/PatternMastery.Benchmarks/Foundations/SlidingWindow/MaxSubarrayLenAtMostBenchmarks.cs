using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Benchmarks.Foundations.SlidingWindow;

[MemoryDiagnoser]
public class MaxSubarrayLenAtMostBenchmarks
{
    private int[] _small = default!;
    private int[] _large = default!;

    [Params(50, 200, 800)]
    public int K { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(123);
        _small = Enumerable.Range(0, 10_000).Select(_ => rnd.Next(0, 10)).ToArray();
        _large = Enumerable.Range(0, 1_000_000).Select(_ => rnd.Next(0, 10)).ToArray();
    }

    [Benchmark]
    public int Small_Find() => MaxSubarrayLenAtMost.Find(K, _small);

    [Benchmark]
    public int Large_Find() => MaxSubarrayLenAtMost.Find(K * 10, _large);
}