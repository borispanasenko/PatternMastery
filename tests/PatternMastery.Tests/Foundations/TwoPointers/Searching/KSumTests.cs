// tests/Foundations/TwoPointers/Searching/KSumTests.cs
using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

public class KSumTests
{
    [Fact]
    public void ThreeSum_zero_basic()
    {
        var nums = new[] { -1, 0, 1, 2, -1, -4 };
        var triples = KSum.FindValues(nums, k: 3, target: 0);

        triples.Should().BeEquivalentTo(new List<List<int>>
        {
            new() { -1, -1, 2 },
            new() { -1, 0, 1 }
        });
    }

    [Fact]
    public void FourSum_target_two()
    {
        var nums = new[] { 1, 0, -1, 0, -2, 2 };
        var quads = KSum.FindValues(nums, k: 4, target: 0);

        quads.Should().BeEquivalentTo(new List<List<int>>
        {
            new() { -2, -1, 1, 2 },
            new() { -2,  0, 0, 2 },
            new() { -1,  0, 0, 1 }
        });
    }

    [Fact]
    public void No_solution_or_too_short()
    {
        KSum.FindValues(Array.Empty<int>(), 3, 0).Should().BeEmpty();
        KSum.FindValues(new[]{1,2}, 3, 3).Should().BeEmpty();
        KSum.FindValues(new[]{5,5,5}, 3, 100).Should().BeEmpty();
    }

    [Fact]
    public void Duplicates_are_collapsed()
    {
        var nums = Enumerable.Repeat(0, 10).ToArray();
        var triples = KSum.FindValues(nums, 3, 0);
        triples.Should().HaveCount(1);
        triples[0].Should().Equal(0,0,0);
    }
}