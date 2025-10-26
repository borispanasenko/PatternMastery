using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.FilteringPartitioning;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.FilteringPartitioning;

public class RemoveDuplicatesSortedTests
{
    [Fact]
    public void Handles_basic_case()
    {
        var a = new[] {1,1,2,2,2,3,3,4};
        int k = RemoveDuplicatesSorted.Run(a);
        k.Should().Be(4);
        a[..k].Should().Equal(1,2,3,4);
    }

    [Fact]
    public void All_unique_already()
    {
        var a = new[] {1,2,3};
        int k = RemoveDuplicatesSorted.Run(a);
        k.Should().Be(3);
        a[..k].Should().Equal(1,2,3);
    }

    [Fact]
    public void Single_element()
    {
        var a = new[] {5};
        int k = RemoveDuplicatesSorted.Run(a);
        k.Should().Be(1);
        a[..k].Should().Equal(5);
    }
}