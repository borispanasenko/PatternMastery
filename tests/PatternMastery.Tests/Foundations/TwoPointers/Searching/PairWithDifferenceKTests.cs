namespace PatternMastery.Tests.Foundations.TwoPointers.Searching;

using FluentAssertions;
using PatternMastery.Foundations.TwoPointers.Searching;
using Xunit;

public class PairWithDifferenceKTests
{
    [Fact]
    public void Unsorted_finds_pair_abs_difference()
    {
        var a = new[] { 7, 1, 5, 9, 2, 12, 3 };
        var k = 2;

        var res = PairWithDifferenceK.Find(a, k);

        res.Should().NotBeNull();
        var (i, j) = res!.Value;

        // verify absolute difference of values equals k
        Math.Abs(a[i] - a[j]).Should().Be(k);
    }

    [Fact]
    public void Unsorted_k_zero_requires_duplicates()
    {
        var a = new[] { 1, 2, 3, 2 };
        var res = PairWithDifferenceK.Find(a, 0);
        res.Should().NotBeNull();

        var (i, j) = res!.Value;
        i.Should().NotBe(j);
        a[i].Should().Be(a[j]);
    }

    [Fact]
    public void Unsorted_absent_returns_null()
    {
        var a = new[] { 1, 4, 10 };
        PairWithDifferenceK.Find(a, 6).Should().BeNull(); // no |x - y| = 6
    }

    [Fact]
    public void Sorted_version_works_linear_time()
    {
        var a = new[] { 1, 3, 5, 7, 9, 11 }; // sorted
        var k = 4;

        var res = PairWithDifferenceKSorted.Find(a, k);

        res.Should().NotBeNull();
        var (i, j) = res!.Value;
        (a[j] - a[i]).Should().Be(k); // j>i because array sorted
    }

    [Fact]
    public void Sorted_k_zero_duplicate_neighbor()
    {
        var a = new[] { 1, 2, 2, 3, 4 }; // sorted with dup
        var res = PairWithDifferenceKSorted.Find(a, 0);
        res.Should().NotBeNull();

        var (i, j) = res!.Value;
        i.Should().NotBe(j);
        a[i].Should().Be(a[j]);
    }

    [Fact]
    public void Negative_k_treated_as_absolute()
    {
        var a = new[] { 10, 3, 6 };
        var res1 = PairWithDifferenceK.Find(a, -4);
        var res2 = PairWithDifferenceK.Find(a, 4);

        res1.HasValue.Should().Be(res2.HasValue);
    }
}