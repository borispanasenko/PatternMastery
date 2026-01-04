using FluentAssertions;
using OptimizationState.StateTransitions.LexicographicNext.PermutationTransition;
using Xunit;

namespace PatternMastery.Tests.OptimizationState.StateTransitions.LexicographicNext.PermutationTransition;

public class NextBiggerTests
{
    [Theory]
    [InlineData(12, 21)]
    [InlineData(513, 531)]
    [InlineData(2017, 2071)]
    [InlineData(414, 441)]
    [InlineData(144, 414)]
    [InlineData(1234321, 1241233)]
    public void Returns_correct_next_bigger_for_valid_numbers(int source, int expected)
    {
        var result = NextBigger.NextBiggerThan(source);
        result.Should().Be(expected);
    }

    [Fact]
    public void Returns_correct_next_bigger_complex_mountain()
    {
        // The "Mountain" example we analyzed:
        // 1 2 (4 3 1) -> Pivot is 2
        // Swap 2 <-> 3 -> 1 3 (4 2 1)
        // Minimize tail -> 1 3 (1 2 4)
        var source = 12431;
        var result = NextBigger.NextBiggerThan(source);
        result.Should().Be(13124);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(321)]
    [InlineData(5)] // Single digit
    [InlineData(0)]
    public void Returns_minus_one_when_no_bigger_exists(int source)
    {
        var result = NextBigger.NextBiggerThan(source);
        result.Should().Be(-1, "digits are already in descending order");
    }
    
    [Fact]
    public void Returns_minus_one_when_result_exceeds_int_max()
    {
        // 2,147,483,647 -> Int.Max
        // Let's take a number slightly smaller, whose permutation exceeds the limit
        // 2147483 4 8 6 (swapping 486 -> 648 results in overflow)
        int source = 2147483486; 
        
        var result = NextBigger.NextBiggerThan(source);
        
        result.Should().Be(-1, "result would overflow integer bounds");
    }

    [Fact]
    public void Throws_argument_exception_when_number_is_negative()
    {
        Action act = () => NextBigger.NextBiggerThan(-5);
        act.Should().Throw<ArgumentException>();
    }
}