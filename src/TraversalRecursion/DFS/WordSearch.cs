namespace TraversalRecursion.DFS;

using System;

public class WordSearch
{
    // --- 1. Discrete world position ---
    public readonly struct Position
    {
        public readonly int R, C;

        public Position(int r, int c) { R = r; C = c; }

        // --- 4. Boundaries check method  ---
        public bool IsInside(char[,] world) =>
            R >= 0 && R < world.GetLength(0) &&
            C >= 0 && C < world.GetLength(1);

        public Position Offset(int dx, int dy) =>
            new Position(R + dx, C + dy);
    }

    // --- 2.1. World geometry moves ---
    public struct Moves
    {
        public readonly (int dx, int dy)[] Steps;

        // --- default geometry (when calling new Moves()) ---
        public Moves() : this(Orthogonal.Steps) { }

        // --- custom constructor ---
        public Moves((int dx, int dy)[] steps)
        {
            Steps = steps;
        }

        // --- Static factories for different geometries ---
        /// <summary>Up, Left, Right, Down</summary>
        public static Moves Orthogonal => new Moves(new[]
        {
            (-1, 0), ( 0, -1), ( 0, 1), ( 1, 0)
        });

        /// <summary>All 8 directions (Boggle style)</summary>
        public static Moves Full8 => new Moves(new[]
        {
            (-1,-1), (-1,0), (-1,1),
            ( 0,-1),        ( 0,1),
            ( 1,-1), ( 1,0), ( 1,1),
        });

    }

    // --- 2.2. Static world context ---
    public readonly struct Context
    {
        public readonly char[,] World;
        public readonly string Pattern;
        public readonly Moves Geometry;

        public Context(char[,] world, string pattern, Moves geometry)
        {
            World = world;
            Pattern = pattern;
            Geometry = geometry;
        }
    }

    // --- 3. Dynamic configuration ---
    public struct Configuration
    {
        public readonly Position Pos;     // current snake position
        public readonly int Index;        // index of the next letter we're looking for
        public readonly bool[,] Visited;  // path matrix model

        public Configuration(Position pos, int index, bool[,] visited)
        {
            Pos = pos;
            Index = index;
            Visited = visited;
        }

        // New configuration for the next step
        public Configuration Next(Position newPos) =>
            new Configuration(newPos, Index + 1, Visited);
    }


    // --- 5. External function Exist ---
    public static bool Exist(char[,] world, string pattern)
    {
        var ctx = new Context(world, pattern, new Moves());

        int rows = world.GetLength(0);
        int cols = world.GetLength(1);

        var visited = new bool[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var startPos = new Position(r, c);
                var conf = new Configuration(startPos, 0, visited);

                if (Search(ctx, conf))
                    return true;
            }
        }

        return false;
    }

    // --- 6. Recursive search ---
    private static bool Search(in Context ctx, Configuration conf)
    {
        // The whole word found
        if (conf.Index == ctx.Pattern.Length)
            return true;

        // Analyzer: Can you enter the next cell?
        if (!conf.Pos.IsInside(ctx.World)) return false;
        if (conf.Visited[conf.Pos.R, conf.Pos.C]) return false;
        if (ctx.World[conf.Pos.R, conf.Pos.C] != ctx.Pattern[conf.Index]) return false;

        // Mark the cell as visited
        conf.Visited[conf.Pos.R, conf.Pos.C] = true;

        // Iterate over all steps
        foreach (var (dx, dy) in ctx.Geometry.Steps)
        {
            var nextPos = conf.Pos.Offset(dx, dy);

            if (Search(ctx, conf.Next(nextPos)))
                return true;
        }

        // Rollback
        conf.Visited[conf.Pos.R, conf.Pos.C] = false;
        return false;
    }

    // --- 7. Example ---
    public static void Main()
    {
        char[,] grid =
        {
            { 'A', 'B', 'C', 'E' },
            { 'S', 'F', 'C', 'S' },
            { 'A', 'D', 'E', 'E' },
        };

        Console.WriteLine(Exist(grid, "ABCCED")); // True
        Console.WriteLine(Exist(grid, "SEE"));    // True
        Console.WriteLine(Exist(grid, "ABCB"));   // False
    }
}
