using PatternMastery.Playground.Foundations.TwoPointers.Searching;
using PatternMastery.Playground.HashingLinear.Lookup;

namespace PatternMastery.Playground;

internal static class Program
{
    private static void Main(string[] args)
    {
        var demos = new IDemo[]
        {
            // I. Foundations
            // 1. Two Pointers
            // A. Searching
            new TwoSumSortedDemo(),
            new PairWithDiffKDemo(),
            new ThreeSumDemo(),
            new ContainerMostWaterDemo(),
            // B. Filtering-Partitioning
            
            // II. Hashing & Linear Structures
            // 1. Lookup
            new TwoSumUnsortedDemo(),
            new PairWithDifferenceKHashDemo(),
        };

        if (args.Length > 0)
        {
            // dotnet run --project playground/PatternMastery.Playground -- two-sum-sorted
            RunByKey(args[0], demos);
        }
        else
        {
            ShowMenuAndRun(demos);
        }
    }

    private static void RunByKey(string key, IEnumerable<IDemo> demos)
    {
        var enumerable = demos as IDemo[] ?? demos.ToArray();
        var demo = enumerable.FirstOrDefault(d => string.Equals(d.Key, key, StringComparison.OrdinalIgnoreCase));
        if (demo is null)
        {
            Console.WriteLine($"Unknown demo '{key}'. Available: " +
                              string.Join(", ", enumerable.Select(d => d.Key)));
            return;
        }
        demo.Run();
    }

    private static void ShowMenuAndRun(IReadOnlyList<IDemo> demos)
    {
        Console.WriteLine("Select a demo:");
        for (int i = 0; i < demos.Count; i++)
            Console.WriteLine($"{i + 1}) {demos[i].Key} — {demos[i].Title}");

        Console.Write("> ");
        var input = Console.ReadLine();
        if (int.TryParse(input, out var n) && n >= 1 && n <= demos.Count)
            demos[n - 1].Run();
        else
            Console.WriteLine("Invalid selection.");
    }

    public static void Header(string title)
    {
        Console.WriteLine();
        Console.WriteLine("=== 40 Patterns ===");
        Console.WriteLine(title);
    }

    public static void ShowArray(string name, int[] a)
        => Console.WriteLine($"{name}: [{string.Join(", ", a)}]");
}

// ----------------- Demo classes -----------------

internal interface IDemo { string Key { get; } string Title { get; } void Run(); }