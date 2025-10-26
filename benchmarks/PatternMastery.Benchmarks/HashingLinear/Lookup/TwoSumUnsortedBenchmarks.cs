using BenchmarkDotNet.Attributes;
using PatternMastery.HashingLinear.Lookup;

namespace PatternMastery.Benchmarks.HashingLinear.Lookup;

[MemoryDiagnoser]
public class TwoSumUnsortedBenchmarks
{
    private int[] _nums = null!;
    private int _target;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _nums = Enumerable.Range(0, 100_000).Select(_ => rnd.Next(0, 1_000_000)).ToArray();

        // Ensure at least one valid pair
        _nums[1000] = 12345;
        _nums[5000] = 98765;
        _target = _nums[1000] + _nums[5000];
    }

    [Benchmark(Baseline = true)]
    public (int i, int j)? FindPair() => TwoSumUnsorted.Find(_nums, _target);
}