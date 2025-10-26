using FluentAssertions;
using PatternMastery.HashingLinear.Lookup;
using Xunit;

namespace PatternMastery.Tests.HashingLinear.Lookup;

public class PairWithDifferenceKHashTests
{
    [Fact]
    public void Finds_pair_when_exists_k_positive()
    {
        var nums = new[] { 7, 1, 5, 9, 2, 12, 3 };
        var res = PairWithDifferenceKHash.Find(nums, 2);

        res.Should().NotBeNull("a pair with diff 2 exists (1,3) or (5,7) etc.");
        var (i, j) = res!.Value;
        Math.Abs(nums[i] - nums[j]).Should().Be(2);
    }

    [Fact]
    public void Returns_null_when_absent()
    {
        var nums = new[] { 1, 4, 8, 13 };
        var res = PairWithDifferenceKHash.Find(nums, 3);
        res.Should().BeNull();
    }

    [Fact]
    public void Handles_k_zero_requires_duplicates()
    {
        var nums = new[] { 3, 8, 3, 10 };
        var res = PairWithDifferenceKHash.Find(nums, 0);

        res.Should().NotBeNull("duplicate 3s exist");
        var (i, j) = res!.Value;
        i.Should().NotBe(j);
        (nums[i] - nums[j]).Should().Be(0);
    }

    [Fact]
    public void Negative_k_treated_as_absolute()
    {
        var nums = new[] { 2, 9, 4 };
        var res = PairWithDifferenceKHash.Find(nums, -5);
        res.Should().NotBeNull();
        var (i, j) = res!.Value;
        Math.Abs(nums[i] - nums[j]).Should().Be(5);
    }
}