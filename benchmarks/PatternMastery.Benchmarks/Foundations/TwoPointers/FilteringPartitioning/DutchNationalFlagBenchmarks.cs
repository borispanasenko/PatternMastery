using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.FilteringPartitioning;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.FilteringPartitioning;

[MemoryDiagnoser]
public class DutchNationalFlagBenchmarks
{
    [Params(1_000, 10_000, 100_000)]
    public int N;

    private int[] _data = default!;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _data = Enumerable.Range(0, N).Select(_ => rnd.Next(0, 3)).ToArray();
    }

    [Benchmark(Baseline = true)]
    public void DNF_InPlace()
    {
        var a = (int[])_data.Clone();
        DutchNationalFlag.Sort012(a);
    }

    [Benchmark]
    public void ArraySort_Compare()
    {
        var a = (int[])_data.Clone();
        Array.Sort(a);
    }
}