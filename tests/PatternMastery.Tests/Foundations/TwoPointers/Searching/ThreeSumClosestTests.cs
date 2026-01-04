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
    
    [Fact]
    public void Returns_target_on_exact_hit()
    {
        ThreeSumClosest.Find(new[] { -1, 2, -3, 4 }, 0).Should().Be(0);
    }
    
    [Fact]
    public void Order_invariance()
    {
        var a = new[] { -4, -1, 1, 2 };
        var b = new[] { 2, 1, -1, -4 };
        ThreeSumClosest.Find(a, 1).Should().Be(1);
        ThreeSumClosest.Find(b, 1).Should().Be(1);
    }
    
    [Fact]
    public void Large_values_safe_with_long()
    {
        var nums = new[] { int.MaxValue, int.MaxValue, -1, -2, -3 };
        ThreeSumClosest.Find(nums, int.MaxValue).Should().Be(int.MaxValue);
    }
    
    [Fact]
    public void Many_duplicates()
    {
        var nums = Enumerable.Repeat(1, 100).Append(-50).Append(49).ToArray();
        ThreeSumClosest.Find(nums, 0).Should().Be(0); // -50 + 1 + 49
    }

}