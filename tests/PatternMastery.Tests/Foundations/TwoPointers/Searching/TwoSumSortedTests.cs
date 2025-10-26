namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

using System.Linq;
using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

public class TwoSumSortedTests
{
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 6 }, 6, 1, 3)]         // 2 + 4
    [InlineData(new[] { 1, 2, 4, 7, 11, 15 }, 15, 2, 4)]   // 4 + 11
    [InlineData(new[] { -5, -2, 0, 3, 9 }, 1, 1, 3)]       // -2 + 3
    [InlineData(new[] { 2, 2, 3, 3 }, 4, 0, 1)]            // duplicates
    public void Finds_pair_when_present(int[] a, int target, int expectedI, int expectedJ)
    {
        var (i, j) = TwoSumSorted.Find(a, target) ?? (-1, -1);
        (i, j).Should().Be((expectedI, expectedJ));
    }

    [Theory]
    [InlineData(new int[] { }, 10)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 100)]
    [InlineData(new[] { 1, 2, 3, 9 }, 8)]
    public void Returns_minus_one_tuple_when_absent(int[] a, int target)
    {
        TwoSumSorted.Find(a, target).Should().Be((-1, -1));
    }

    [Fact]
    public void Does_not_modify_input_array()
    {
        var a = new[] { 1, 2, 3, 4, 6 };
        var snapshot = a.ToArray();
        _ = TwoSumSorted.Find(a, 6);
        a.Should().Equal(snapshot);
    }
}