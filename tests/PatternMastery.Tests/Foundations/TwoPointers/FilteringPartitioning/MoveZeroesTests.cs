using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.FilteringPartitioning;
using Xunit;

namespace PatternMastery.Tests.Foundations.TwoPointers.FilteringPartitioning;

public class MoveZeroesTests
{
    [Fact]
    public void Moves_zeros_to_end_stably()
    {
        var a = new[] {0,1,0,3,12};
        MoveZeroes.Run(a);
        a.Should().Equal(1,3,12,0,0);
    }

    [Fact]
    public void No_zeros()
    {
        var a = new[] {1,2,3};
        MoveZeroes.Run(a);
        a.Should().Equal(1,2,3);
    }

    [Fact]
    public void All_zeros()
    {
        var a = new[] {0,0,0};
        MoveZeroes.Run(a);
        a.Should().Equal(0,0,0);
    }
}