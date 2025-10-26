using FluentAssertions;
using PatternMastery.HashingLinear.Lookup;
using Xunit;

namespace PatternMastery.Tests.HashingLinear.Lookup;

public class TwoSumUnsortedTests
{
    [Theory]
    [InlineData(new[] { 7, 2, 5, 3, 11 }, 10)]
    [InlineData(new[] { -1, 0, 1, 2, -1, -4 }, 0)]
    [InlineData(new[] { 3, 2, 4 }, 6)]
    public void Finds_pair_in_unsorted_array(int[] nums, int target)
    {
        var result = TwoSumUnsorted.Find(nums, target);

        result.Should().NotBeNull();
        var (i, j) = result!.Value;

        i.Should().BeInRange(0, nums.Length - 1);
        j.Should().BeInRange(0, nums.Length - 1);
        i.Should().NotBe(j);

        (nums[i] + nums[j]).Should().Be(target);
    }

    [Fact]
    public void Returns_null_when_no_pair_exists()
    {
        var nums = new[] { 1, 2, 3 };
        TwoSumUnsorted.Find(nums, 100).Should().BeNull();
    }

    [Fact]
    public void Handles_duplicates_correctly()
    {
        var nums = new[] { 3, 3, 4, 5 };
        const int target = 6;

        var result = TwoSumUnsorted.Find(nums, target);

        result.Should().NotBeNull();
        var (i, j) = result!.Value;
        i.Should().NotBe(j);
        (nums[i] + nums[j]).Should().Be(target);
    }

    [Fact]
    public void Does_not_reuse_the_same_element()
    {
        var nums = new[] { 3, 4, 5 };
        const int target = 8; // would be 4+4, but there is only one 4

        TwoSumUnsorted.Find(nums, target).Should().BeNull();
    }
}