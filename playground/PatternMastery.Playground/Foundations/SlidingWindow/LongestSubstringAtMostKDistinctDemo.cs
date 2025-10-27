using System;
using PatternMastery.Foundations.SlidingWindow;

namespace PatternMastery.Playground.Foundations.SlidingWindow;

internal sealed class LongestSubstringAtMostKDistinctDemo : IDemo
{
    public string Key => "longest-substring-k-distinct";
    public string Title => "Foundations / Sliding Window / LongestSubstringAtMostKDistinct";

    public void Run()
    {
        Program.Header(Title);

        var samples = new (string s, int k)[]
        {
            ("eceba", 2),
            ("aa", 1),
            ("abcadcacacaca", 3),
            ("", 2),
            ("a", 0),
        };

        foreach (var (s, k) in samples)
        {
            var res = LongestSubstringAtMostKDistinct.Find(s, k);
            if (res is { } r)
            {
                var sub = LongestSubstringAtMostKDistinct.Extract(s, k);
                Console.WriteLine($"s=\"{s}\", k={k} → start={r.start}, len={r.length}, sub=\"{sub}\"");
            }
            else
            {
                Console.WriteLine($"s=\"{s}\", k={k} → invalid (null)");
            }
        }
    }
}