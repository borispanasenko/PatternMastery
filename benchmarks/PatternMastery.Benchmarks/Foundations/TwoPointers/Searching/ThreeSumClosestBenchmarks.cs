using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

[MemoryDiagnoser]
public class ThreeSumClosestBenchmarks
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

        _targetSmall = 7;
        _targetLarge = 123;
    }

    [Benchmark(Baseline = true)]
    public int SmallArray()
        => ThreeSumClosest.Find(_numsSmall, _targetSmall);

    [Benchmark]
    public int LargeArray()
        => ThreeSumClosest.Find(_numsLarge, _targetLarge);
}