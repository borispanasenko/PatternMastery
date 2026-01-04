using System;
using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

public class ThreeSumSmallerCountTests
{
    [Theory]
    [InlineData(new[] { -2, 0, 1, 3 }, 2, 2)]
    [InlineData(new[] { 0, 0, 0 }, 1, 1)]
    [InlineData(new[] { 1, 1, 1, 1 }, 4, 4)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 8, 4)]
    
    public void Counts_triplets_with_sum_smaller_than_target(
        int[] nums, int target, int expected)
        => ThreeSumSmallerCount.Count(nums, target).Should().Be(expected);

    [Fact]
    public void Throws_on_too_short_input()
    {
        Action act = () => ThreeSumSmallerCount.Count(new[] { 1, 2 }, 0);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Order_invariance()
    {
        var a = new[] { -2, 0, 1, 3 };
        var b = new[] { 3, 1, 0, -2 };

        ThreeSumSmallerCount.Count(a, 2).Should()
            .Be(ThreeSumSmallerCount.Count(b, 2));
    }
}