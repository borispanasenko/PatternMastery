using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class ThreeSumSmallerBenchmarks
{
    private int[] _numsSmall = null!;
    private int[] _numsLarge = null!;

    private int _targetSmall;
    private int _targetLarge;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);

        _numsSmall = Enumerable.Range(0, 200)
            .Select(_ => rnd.Next(-50, 50))
            .ToArray();

        _numsLarge = Enumerable.Range(0, 2000)
            .Select(_ => rnd.Next(-1000, 1000))
            .ToArray();

        // Some representative targets
        _targetSmall = 10;
        _targetLarge = 100;
    }

    [Benchmark(Baseline = true)]
    public int SmallArray()
        => ThreeSumSmaller.Find(_numsSmall, _targetSmall);

    [Benchmark]
    public int LargeArray()
        => ThreeSumSmaller.Find(_numsLarge, _targetLarge);
}