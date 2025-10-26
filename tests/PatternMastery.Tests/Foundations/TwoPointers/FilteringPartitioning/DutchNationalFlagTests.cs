using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.FilteringPartitioning;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.FilteringPartitioning;

public class DutchNationalFlagTests
{
    [Fact]
    public void Sorts_0_1_2_in_place()
    {
        var a = new[] {2,0,2,1,1,0};
        DutchNationalFlag.Sort012(a);
        a.Should().Equal(0,0,1,1,2,2);
    }

    [Fact]
    public void Already_sorted()
    {
        var a = new[] {0,0,1,1,2,2};
        DutchNationalFlag.Sort012(a);
        a.Should().Equal(0,0,1,1,2,2);
    }

    [Fact]
    public void Single_element_ok()
    {
        var a = new[] {1};
        DutchNationalFlag.Sort012(a);
        a.Should().Equal(1);
    }
}