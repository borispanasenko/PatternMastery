// benchmarks/Foundations/TwoPointers/Searching/FourSumBenchmarks.cs
using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class FourSumBenchmarks
{
    private int[] _arr = null!;

    [Params(0)]
    public int Target { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _arr = Enumerable.Range(0, 5000)
            .Select(_ => rnd.Next(-1000, 1000))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public int CountQuadruples()
    {
        var res = FourSum.FindValues(_arr, Target);
        return res.Count;
    }
}