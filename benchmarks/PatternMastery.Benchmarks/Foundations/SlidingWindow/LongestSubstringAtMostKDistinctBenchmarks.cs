using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Benchmarks.Foundations.SlidingWindow;

[MemoryDiagnoser]
public class LongestSubstringAtMostKDistinctBenchmarks
{
    private readonly string _data = new string('a', 10000) + new string('b', 10000) + new string('c', 10000);

    [Params(1, 2, 3)]
    public int K { get; set; }

    [Benchmark]
    public (int start, int length)? Find() => LongestSubstringAtMostKDistinct.Find(_data, K);
}