namespace PatternMastery.Tests.Foundations.SlidingWindow;

using FluentAssertions;
using PatternMastery.Foundations.SlidingWindow;
using Xunit;

public class MinSubarrayLenAtLeastTests
{
    [Theory]
    [InlineData(7,  new[] {2,3,1,2,4,3}, 2)]   // [4,3]
    [InlineData(4,  new[] {1,4,4},        1)]   // [4]
    [InlineData(11, new[] {1,1,1,1,1,1,1}, 0)]  // none
    [InlineData(5,  new[] {5},             1)]  // [5]
    public void Find_returns_expected_min_length(int target, int[] nums, int expected)
    {
        MinSubarrayLenAtLeast.Find(target, nums).Should().Be(expected);
    }

    [Fact]
    public void Find_handles_empty_and_non_positive_target()
    {
        MinSubarrayLenAtLeast.Find(0, Array.Empty<int>()).Should().Be(0);
        MinSubarrayLenAtLeast.Find(10, Array.Empty<int>()).Should().Be(0);
    }

    [Fact]
    public void Find_handles_all_zeroes_properly()
    {
        MinSubarrayLenAtLeast.Find(1, new[] {0,0,0}).Should().Be(0);
        MinSubarrayLenAtLeast.Find(0, new[] {0,0,0}).Should().Be(0);
    }

    [Fact]
    public void Find_throws_on_null_input()
    {
        Action act = () => MinSubarrayLenAtLeast.Find(5, null!);
        act.Should().Throw<ArgumentNullException>();
    }
}