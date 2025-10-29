namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

public class ThreeSumClosestTests
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 1, 2)]     // (-1 + 2 + 1) = 2
    [InlineData(new[] { 0, 0, 0 }, 1, 0)]
    [InlineData(new[] { 1, 1, 1, 0 }, -100, 2)]
    [InlineData(new[] { 1, 2, 5, 10, 11 }, 12, 13)] // 1+2+10=13 vs 1+10+11=22
    public void Finds_closest_sum(int[] nums, int target, int expected)
        => ThreeSumClosest.Find(nums, target).Should().Be(expected);

    [Fact]
    public void Throws_on_too_short_input()
    {
        Action act = () => ThreeSumClosest.Find(new[] { 1, 2 }, 0);
        act.Should().Throw<ArgumentException>();
    }
}