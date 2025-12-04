namespace CSharp.Day04;

public static class GridOfPaper
{
    public static int GetNumberOfAccessedRolls(char[][] grid)
    {
        int count = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == '@')
                {
                    if (GetNumberOfRollsInAdjacentPositions(grid, row, col) < 4)
                    {
                        count++;
                    }
                }
            }
        }
        
        return count;
    }
    public static int GetNumberOfRemovableRolls(char[][] grid)
    {
        int totalCount = 0;

        while (true)
        {
            int count = 0;
            var rollsToRemove = new List<(int, int)>();
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == '@')
                    {
                        if (GetNumberOfRollsInAdjacentPositions(grid, row, col) < 4)
                        {
                            count++;
                            rollsToRemove.Add((row, col));
                        }
                    }
                }
            }
            if (count == 0)
            {
                break;
            }
            totalCount += count;
            foreach (var r in rollsToRemove)
            {
                grid[r.Item1][r.Item2] = 'x';
            }
        }
        
        return totalCount;
    }
    

    private static int GetNumberOfRollsInAdjacentPositions(char[][] grid, int row, int col)
    {
        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
    
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0)
                    continue;
            
                int newRow = row + dr;
                int newCol = col + dc;
            
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    if (grid[newRow][newCol] == '@')
                        count++;
                }
            }
        }
    
        return count;
    }
}