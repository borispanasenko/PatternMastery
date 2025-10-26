namespace PatternMastery.Benchmarks.Foundations.TwoPointers.Searching;

using System;
using BenchmarkDotNet.Attributes;
using PatternMastery.Foundations.TwoPointers.Searching;

public class TwoSumSortedBenchmarks
{
    private int[] _data = Array.Empty<int>();
    private int _target;

    [GlobalSetup]
    public void Setup()
    {
        var rnd = new Random(42);
        _data = new int[100_000];
        _data[0] = rnd.Next(0, 5);
        for (int i = 1; i < _data.Length; i++)
            _data[i] = _data[i - 1] + rnd.Next(0, 3);
        _target = _data[^1] + _data[^2];
    }

    [Benchmark]
    public (int, int)? Find() => TwoSumSorted.Find(_data, _target);
}
