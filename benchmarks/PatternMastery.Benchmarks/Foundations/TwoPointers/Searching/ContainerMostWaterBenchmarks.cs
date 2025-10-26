using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class ContainerMostWaterBenchmarks
{
    private int[] _heights = null!;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _heights = Enumerable.Range(0, 100_000).Select(_ => rnd.Next(0, 1000)).ToArray();
    }

    [Benchmark(Baseline = true)]
    public (int area, int i, int j) Compute() => ContainerMostWater.Find(_heights);
}