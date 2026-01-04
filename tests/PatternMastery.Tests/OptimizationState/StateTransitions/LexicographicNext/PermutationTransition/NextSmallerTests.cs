using FluentAssertions;
using OptimizationState.StateTransitions.LexicographicNext.PermutationTransition;
using Xunit;

namespace PatternMastery.Tests.OptimizationState.StateTransitions.LexicographicNext.PermutationTransition;

public class NextSmallerTests
{
    [Theory]
    [InlineData(21, 12)]
    [InlineData(531, 513)]
    [InlineData(2071, 2017)]
    [InlineData(31, 13)]
    public void Returns_correct_next_smaller_for_valid_numbers(int source, int expected)
    {
        var result = NextSmaller.NextSmallerThan(source);
        result.Should().Be(expected);
    }

    [Fact]
    public void Returns_correct_next_smaller_complex_valley()
    {
        // Inverse scenario to 12431 -> 13124
        // Taking 13124. Searching for the nearest smaller number.
        // Expecting 12431.
        var source = 13124;
        var result = NextSmaller.NextSmallerThan(source);
        result.Should().Be(12431);
    }

    [Theory]
    [InlineData(123)]
    [InlineData(1)]
    [InlineData(0)]
    public void Returns_minus_one_when_no_smaller_exists(int source)
    {
        var result = NextSmaller.NextSmallerThan(source);
        result.Should().Be(-1, "digits are already in ascending order");
    }
    
    [Fact]
    public void Symmetry_invariant_holds()
    {
        // This is a crucial architectural test.
        // It verifies that NextBigger and NextSmaller are inverse operations.
        var start = 12431;
        
        var bigger = NextBigger.NextBiggerThan(start);
        bigger.Should().Be(13124);

        var backToStart = NextSmaller.NextSmallerThan(bigger);
        backToStart.Should().Be(start, "NextSmaller should reverse the action of NextBigger");
    }
}