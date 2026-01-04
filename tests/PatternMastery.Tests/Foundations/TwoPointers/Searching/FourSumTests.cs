// tests/Foundations/TwoPointers/Searching/FourSumTests.cs
using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

public class FourSumTests
{
    [Fact]
    public void FourSum_zero_basic()
    {
        var nums = new[] { 1, 0, -1, 0, -2, 2 };

        var quads = FourSum.FindValues(nums, target: 0);

        quads.Should().BeEquivalentTo(new List<List<int>>
        {
            new() { -2, -1, 1,  2 },
            new() { -2,  0, 0,  2 },
            new() { -1,  0, 0,  1 }
        });
    }

    [Fact]
    public void Too_short_or_null_returns_empty()
    {
        FourSum.FindValues(Array.Empty<int>(), 0).Should().BeEmpty();
        FourSum.FindValues(new[] { 1, 2, 3 }, 6).Should().BeEmpty();

        int[]? nullArray = null;
        FourSum.FindValues(nullArray!, 0).Should().BeEmpty();
    }

    [Fact]
    public void No_solution_returns_empty()
    {
        var nums = new[] { 5, 1, 3, 7, 9 };

        var quads = FourSum.FindValues(nums, target: 100);

        quads.Should().BeEmpty();
    }

    [Fact]
    public void Duplicates_are_collapsed()
    {
        var nums = Enumerable.Repeat(0, 10).ToArray();

        var quads = FourSum.FindValues(nums, target: 0);

        quads.Should().HaveCount(1);
        quads[0].Should().Equal(0, 0, 0, 0);
    }

    [Fact]
    public void Quadruples_are_non_decreasing_and_unique()
    {
        var nums = new[] { 2, 2, 2, 2, 2, -1, -1, 0, 0, 1, 1 };
        var target = 4;

        var quads = FourSum.FindValues(nums, target);

        // Check each quadruple is non-decreasing
        foreach (var q in quads)
        {
            q.Should().BeInAscendingOrder();
        }

        // Check there are no duplicate quadruples
        var seen = new HashSet<string>();
        foreach (var q in quads)
        {
            var key = string.Join(",", q);
            seen.Add(key).Should().BeTrue("quadruples should be unique");
        }
    }
}
