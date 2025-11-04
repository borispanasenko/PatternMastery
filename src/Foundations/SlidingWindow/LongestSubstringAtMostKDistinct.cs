namespace PatternMastery.Foundations.SlidingWindow;

/// <summary>
/// Longest substring with at most K distinct characters (Sliding Window).
/// State S = frequency map; Invariant: distinct ≤ K.
/// Returns (start, length); null for k < 0.
/// Time: O(n); Space: O(min(n, alphabet))
/// </summary>
public static class LongestSubstringAtMostKDistinct
{
    public static (int start, int length)? Find(string s, int k)
    {
        if (s is null) throw new ArgumentNullException(nameof(s));
        if (k < 0) return null;
        if (k == 0) return (0, 0);

        var freq = new Dictionary<char, int>();
        int i = 0, bestStart = 0, bestLen = 0;

        for (int j = 0; j < s.Length; j++)
        {
            char cj = s[j];
            freq.TryGetValue(cj, out int cnt);
            freq[cj] = cnt + 1;

            while (freq.Count > k)
            {
                char ci = s[i++];
                if (--freq[ci] == 0)
                    freq.Remove(ci);
            }

            int len = j - i + 1;
            if (len > bestLen)
            {
                bestLen = len;
                bestStart = i;
            }
        }

        return (bestStart, bestLen);
    }

    public static string Extract(string s, int k)
    {
        var res = Find(s, k);
        if (res is null) return string.Empty;
        var (start, len) = res.Value;
        return len == 0 ? string.Empty : s.Substring(start, len);
    }
}