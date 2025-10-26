using BenchmarkDotNet.Attributes;
using PatternMastery.HashingLinear.Lookup;

namespace PatternMastery.Benchmarks.HashingLinear.Lookup;

[MemoryDiagnoser]
public class PairWithDifferenceKHashBenchmarks
{
    [Params(1_000, 10_000, 100_000)]
    public int N;

    [Params(0, 1, 5, 50)]
    public int K;

    private int[] _dataWithHit = default!;
    private int[] _dataNoHit = default!;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(12345);

        // with hit: place a pair differing by K (or a duplicate if K==0)
        _dataWithHit = Enumerable.Range(0, N).Select(_ => rnd.Next(0, N)).ToArray();
        if (K == 0)
        {
            // ensure duplicate
            if (N >= 2) _dataWithHit[1] = _dataWithHit[0];
        }
        else
        {
            // ensure x and x+K exist
            if (N >= 2)
            {
                _dataWithHit[0] = 10_000;
                _dataWithHit[1] = 10_000 + K;
            }
        }

        // no hit: try to avoid differences of K (best-effort)
        _dataNoHit = Enumerable.Range(0, N)
            .Select(i => i * (K == 0 ? 2 : (K + 1))) // spread values to avoid exact diff K or duplicates
            .ToArray();
    }

    [Benchmark(Baseline = true)]
    public (int i, int j)? Find_WithHit()
        => PairWithDifferenceKHash.Find(_dataWithHit, K);

    [Benchmark]
    public (int i, int j)? Find_NoHit()
        => PairWithDifferenceKHash.Find(_dataNoHit, K);
}