namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        int[,] grid = new int[3, 3];

        string[] numbers = { "1", "2", "3" };

        Random random = new Random();

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                int randomIndex = random.Next(numbers.Length);
                grid[row, column] = Convert.ToInt32(numbers[randomIndex]);
            }
        }

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                Console.Write($"{grid[row, column]} ");
            }

            Console.WriteLine();
        }
    }
}