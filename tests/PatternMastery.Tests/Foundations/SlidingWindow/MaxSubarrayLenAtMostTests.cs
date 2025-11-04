namespace PatternMastery.Tests.Foundations.SlidingWindow;

using FluentAssertions;
using PatternMastery.Foundations.SlidingWindow;
using Xunit;

public class MaxSubarrayLenAtMostTests
{
    [Theory]
    [InlineData(8, new[] {2,1,2,2,1}, 5)]   // вся последовательность подходит
    [InlineData(5, new[] {1,2,3,1,1}, 3)]   // напр., [1,2,2] нет; корректно — [1,2,1] или [3,1] и т.п.
    [InlineData(0, new[] {1,2,3}, 0)]       // ни одного окна
    [InlineData(100, new[] {5,5,5,5,5}, 5)] // всё подходит
    public void Find_returns_expected_max_length(int k, int[] nums, int expected)
    {
        MaxSubarrayLenAtMost.Find(k, nums).Should().Be(expected);
    }

    [Fact]
    public void Find_handles_empty_and_negative_k()
    {
        MaxSubarrayLenAtMost.Find(5, Array.Empty<int>()).Should().Be(0);
        MaxSubarrayLenAtMost.Find(-1, new[] {1,2,3}).Should().Be(0);
    }

    [Fact]
    public void Find_throws_on_null_input()
    {
        Action act = () => MaxSubarrayLenAtMost.Find(10, null!);
        act.Should().Throw<ArgumentNullException>();
    }
}