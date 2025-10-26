using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

public class ThreeSumTests
{
    [Fact]
    public void Values_basic_case()
    {
        var nums = new[] { -1, 0, 1, 2, -1, -4 };
        var res = ThreeSum.FindValues(nums);
        res.Should().BeEquivalentTo(new (int,int,int)[]
        {
            (-1, -1, 2),
            (-1, 0, 1)
        }, options => options.WithoutStrictOrdering());
    }

    [Fact]
    public void Values_no_solution()
    {
        var nums = new[] { 1, 2, 3 };
        ThreeSum.FindValues(nums).Should().BeEmpty();
    }

    [Fact]
    public void Indices_map_back()
    {
        var nums = new[] { -1, 0, 1, 2, -1, -4 };
        var triples = ThreeSum.FindIndices(nums);

        // At least one triple should correspond to (-1, 0, 1) by value:
        triples.Should().Contain(t => nums[t.i] + nums[t.j] + nums[t.k] == 0);
    }
}