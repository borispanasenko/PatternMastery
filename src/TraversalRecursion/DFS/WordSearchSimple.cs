namespace TraversalRecursion.DFS;

using System;

public class WordSearchSimple
{
    public static bool Exist(char[,] board, string word)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);
        bool[,] visited = new bool[rows, cols];

        // 4 basic moves: up, left, right, down
        (int dx, int dy)[] moves =
        {
            (-1, 0), (0, -1), (0, 1), (1, 0)
        };

        // Try starting from every cell
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (Search(board, word, 0, r, c, visited, moves))
                    return true;
            }
        }

        return false;
    }

    private static bool Search(char[,] board, string word, int index,
                               int r, int c, bool[,] visited,
                               (int dx, int dy)[] moves)
    {
        // Word fully matched
        if (index == word.Length)
            return true;

        // Check if inside the board
        if (r < 0 || r >= board.GetLength(0)) return false;
        if (c < 0 || c >= board.GetLength(1)) return false;

        // Already visited or does not match required letter
        if (visited[r, c]) return false;
        if (board[r, c] != word[index]) return false;

        // Mark cell as visited
        visited[r, c] = true;

        // Explore all possible moves
        foreach (var (dx, dy) in moves)
        {
            if (Search(board, word, index + 1, r + dx, c + dy, visited, moves))
                return true;
        }

        // Backtrack: unmark cell
        visited[r, c] = false;
        return false;
    }

    public static void Main()
    {
        char[,] grid =
        {
            { 'A', 'B', 'C', 'E' },
            { 'S', 'F', 'C', 'S' },
            { 'A', 'D', 'E', 'E' }
        };

        Console.WriteLine(Exist(grid, "ABCCED")); // True
        Console.WriteLine(Exist(grid, "SEE"));    // True
        Console.WriteLine(Exist(grid, "ABCB"));   // False
    }
}
