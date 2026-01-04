using FluentAssertions;
using OptimizationState.StateTransitions.LexicographicNext.BitTransitions;
using Xunit;

namespace PatternMastery.Tests.OptimizationState.StateTransitions.LexicographicNext.BitTransitions;

public class NextWithSameBitCountTests
{
    [Fact]
    public void Finds_next_value_simple_case()
    {
        // 6  dec = 0110 bin (2 bits)
        // 7  dec = 0111 bin (3 bits) - invalid count
        // 8  dec = 1000 bin (1 bit)  - invalid count
        // 9  dec = 1001 bin (2 bits) - MATCH
        var result = BitTransitionExtension.NextWithSameBitCount(6);
        result.Should().Be(9);
    }

    [Theory]
    [InlineData(1, 2)]     // 001 -> 010
    [InlineData(2, 4)]     // 010 -> 100
    [InlineData(4, 8)]     // 100 -> 1000
    public void Handles_powers_of_two_shifting_bit_left(int source, int expected)
    {
        // For powers of two (single bit), the next value is simply a multiplication by 2 (left shift)
        var result = BitTransitionExtension.NextWithSameBitCount(source);
        result.Should().Be(expected);
    }

    [Fact]
    public void Handles_block_shift_logic()
    {
        // 12 dec = 1100 bin
        // Pivot: Rightmost 1 (bit at position 4).
        // Ripple: 12 + 4 = 16 (10000 bin).
        // Tail recovery: One set bit was "lost" during ripple. It must be placed at the lowest possible position.
        // Result: 10001 bin = 17 dec.
        var result = BitTransitionExtension.NextWithSameBitCount(12);
        result.Should().Be(17);
    }

    [Fact]
    public void Returns_minus_one_on_overflow()
    {
        // Int.MaxValue = 0111...111
        // It has no "next" value within positive integers, 
        // as adding a bit would shift into the sign bit (negative number).
        var result = BitTransitionExtension.NextWithSameBitCount(int.MaxValue);
        result.Should().Be(-1);
    }
}