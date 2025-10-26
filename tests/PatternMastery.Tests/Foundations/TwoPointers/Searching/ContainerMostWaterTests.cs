using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

public class ContainerMostWaterTests
{
    [Fact]
    public void Basic_example()
    {
        var h = new[] {1,8,6,2,5,4,8,3,7};
        var (area, i, j) = ContainerMostWater.Find(h);

        area.Should().Be(49);
        (i, j).Should().Be((1, 8)); // one optimal solution
    }

    [Fact]
    public void Too_short()
    {
        var (area, i, j) = ContainerMostWater.Find(new[] { 5 });
        area.Should().Be(0);
        (i, j).Should().Be((-1, -1));
    }
}