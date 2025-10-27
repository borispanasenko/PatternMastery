namespace PatternMastery.Tests.Foundations.SlidingWindow;

using FluentAssertions;
using PatternMastery.Foundations.SlidingWindow;
using Xunit;

public class LongestSubstringAtMostKDistinctTests
{
    [Theory]
    [InlineData("eceba", 2, "ece")]
    [InlineData("aa", 1, "aa")]
    [InlineData("", 2, "")]
    [InlineData("a", 0, "")]
    [InlineData("aabacbebebe", 3, "cbebebe")]
    public void Extract_returns_expected_substring(string s, int k, string expected)
    {
        LongestSubstringAtMostKDistinct.Extract(s, k).Should().Be(expected);
    }

    [Fact]
    public void Find_returns_null_for_negative_k()
    {
        LongestSubstringAtMostKDistinct.Find("abc", -1).Should().BeNull();
    }

    [Fact]
    public void Find_handles_all_same_characters()
    {
        var (start, len) = LongestSubstringAtMostKDistinct.Find("aaaaa", 1)!.Value;
        (start, len).Should().Be((0, 5));
    }
}