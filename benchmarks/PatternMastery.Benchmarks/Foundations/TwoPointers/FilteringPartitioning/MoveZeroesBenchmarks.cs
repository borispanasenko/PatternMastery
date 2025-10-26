using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.FilteringPartitioning;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.FilteringPartitioning;

[MemoryDiagnoser]
public class MoveZeroesBenchmarks
{
    [Params(1_000, 10_000, 100_000)]
    public int N;

    private int[] _data = default!;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _data = Enumerable.Range(0, N)
            .Select(_ => rnd.Next(0, 5) == 0 ? 0 : rnd.Next(1, 100))
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public void MoveZeroes_InPlace()
    {
        var a = (int[])_data.Clone();
        MoveZeroes.Run(a);
    }

    [Benchmark]
    public void Naive_Stable_Rebuild()
    {
        var a = (int[])_data.Clone();
        var nonZero = a.Where(x => x != 0).ToArray();
        var k = nonZero.Length;
        Array.Copy(nonZero, a, k);
        Array.Fill(a, 0, k, a.Length - k);
    }
}