namespace SlotMachine;

public class SlotMachineActions
{
    public static int[,] CreateGrid(int rows, int columns, Random random)
    {
        int[,] grid = new int[rows, columns];
        int[] numbers = { 1, 2, 3 };

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                int randomIndex = random.Next(numbers.Length);
                grid[row, column] = numbers[randomIndex];
            }
        }

        return grid;
    }

    public static void DisplayGrid(int [,] grid)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                Console.Write($"{grid[row, column]} ");
            }

            Console.WriteLine();
        }
    }
    
    public static bool CheckHorizontalLine(int[,] grid, int row)
    {
        int firstNumber = grid[row, 0];

        for (int column = 1; column < grid.GetLength(1); column++)
        {
            if (grid[row, column] != firstNumber)
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckVerticalLine(int[,] grid, int column)
    {
        int firstNumber = grid[0, column];

        for (int row = 1; row < grid.GetLength(1); row++)
        {
            if (grid[row, column] != firstNumber)
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckDiagonalTopLeft(int[,] grid)
    {
        int firsNumber = grid[0, 0];

        for (int i = 1; i < grid.GetLength(0); i++)
        {
            if (grid[i, i] != firsNumber)
            {
                return false;
            }
        }

        return true;
    }

    public static bool CheckDiagonalTopRight(int[,] grid)
    {
        int lastIndex = grid.GetLength(0) - 1;

        int firstNumber = grid[0, lastIndex];

        for (int i = 1; i < grid.GetLength(0); i++)
        {
            if (grid[i, lastIndex - i] != firstNumber)
            {
                return false;
            }
        }

        return true;
    }
}