namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

using System;
using System.Linq;
using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

public class ThreeSumSmallerTests
{
    [Theory]
    [InlineData(new[] { -2, 0, 1, 3 }, 2, 1)]      // -2+0+3 = 1 (best < 2)
    [InlineData(new[] { 0, 0, 0 }, 1, 0)]          // 0+0+0 = 0
    [InlineData(new[] { 1, 2, 5, 10, 11 }, 12, 8)] // 1+2+5 = 8
    [InlineData(new[] { -5, 1, 1, 1, 2 }, 0, -2)]  // -5+2+1 = -2 (better than -3)
    [InlineData(new[] { -1, 2, 1, -4 }, 1, -1)]    // -4+2+1=-1, -1+2+1=2(>=1) → -1
    public void Finds_maximal_sum_strictly_smaller_than_target(
        int[] nums, int target, int expected)
        => ThreeSumSmaller.Find(nums, target).Should().Be(expected);

    [Fact]
    public void Throws_on_too_short_input()
    {
        Action act1 = () => ThreeSumSmaller.Find(Array.Empty<int>(), 0);
        Action act2 = () => ThreeSumSmaller.Find(new[] { 1, 2 }, 0);

        act1.Should().Throw<ArgumentException>();
        act2.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Throws_when_no_triplet_is_smaller_than_target()
    {
        // Any triplet >= 10
        var nums = new[] { 5, 6, 7, 8 };
        Action act = () => ThreeSumSmaller.Find(nums, 10);

        act.Should().Throw<InvalidOperationException>()
           .WithMessage("*No triplet with sum smaller than target*");
    }

    [Fact]
    public void Order_invariance()
    {
        var a = new[] { -2, 0, 1, 3 };
        var b = new[] { 3, 1, 0, -2 };

        ThreeSumSmaller.Find(a, 2).Should().Be(1);
        ThreeSumSmaller.Find(b, 2).Should().Be(1);
    }

    [Fact]
    public void Many_duplicates()
    {
        var nums = Enumerable.Repeat(1, 100)
                             .Append(-50)
                             .Append(49)
                             .ToArray();

        // -50 + 1 + 49 = 0 < 1, better than any 1+1+1
        ThreeSumSmaller.Find(nums, 1).Should().Be(0);
    }

    [Fact]
    public void Large_values_safe_with_long()
    {
        var nums = new[] { int.MaxValue, int.MaxValue, -1, -2, -3 };

        // target = int.MaxValue - 1.
        // int.MaxValue + (-1) + (-2) = int.MaxValue - 3 < target
        // Any combination with int.MaxValue is >> target.
        // So best sum < target must be int.MaxValue - 3.
        var target = int.MaxValue - 1;
        var result = ThreeSumSmaller.Find(nums, target);

        result.Should().Be(int.MaxValue - 3);
    }
}
