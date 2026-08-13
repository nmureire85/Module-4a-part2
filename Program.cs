namespace SlotMachine;

class Program
{
    static void Main(string[] args)
    {
        /*
        Have some money for the player.
        Ask how much they want to wager.
        Ask which lines they want to play.
        Create a dynamic slot grid.
        Display that grid.
        Check whether selected central/horizontal lines contain a winning combination.
        Check vertical lines.
        Check diagonals.
        Add winnings to the player's money.
        Show the result.*/

        const decimal PAYOUT_PER_LINE = 1;
        const decimal STARTING_MONEY = 100;

        decimal money = STARTING_MONEY;
        Console.WriteLine($"You have £{money}");
        Console.Write("Enter your wager: £");
        decimal wager = decimal.Parse(Console.ReadLine());

        if (wager > money)
        {
            Console.WriteLine("You don't have enough money.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Chose which lines to play:");
        Console.WriteLine();
        Console.WriteLine("1. Centre horizontal");
        Console.WriteLine("2. All horizontal");
        Console.WriteLine("3. All vertical");
        Console.WriteLine("4. Both diagonals");
        Console.WriteLine("5. All lines");


        int choice = int.Parse(Console.ReadLine());

        money -= wager;

        Console.WriteLine("Enter row dimension for your grid");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter column dimension for your grid");
        int columns = int.Parse(Console.ReadLine());

        Console.WriteLine();

        int[,] grid = new int[rows, columns];
        int[] numbers = { 1, 2, 3 };

        Random random = new Random();

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                int randomIndex = random.Next(numbers.Length);
                grid[row, column] = numbers[randomIndex];
            }
        }

        Console.WriteLine();
        Console.WriteLine("Here is your spin:");

        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int column = 0; column < grid.GetLength(1); column++)
            {
                Console.Write($"{grid[row, column]} ");
            }

            Console.WriteLine();
        }

        int winningLines = 0;

        switch (choice)
        {
            case 1:
                int centerRow = grid.GetLength(0) / 2;
                if (CheckHorizontalLine(grid, centerRow))
                {
                    winningLines++;
                }

                break;

            case 2:
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (CheckHorizontalLine(grid, row))
                    {
                        winningLines++;
                    }
                }

                break;

            case 3:
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (CheckVerticalLine(grid, column))
                    {
                        winningLines++;
                    }
                }

                break;

            case 4:
                if (CheckDiagonalTopLeft(grid))
                {
                    winningLines++;
                }

                if (CheckDiagonalTopRight(grid))
                {
                    winningLines++;
                }

                break;

            case 5:

                centerRow = grid.GetLength(0) / 2;
                if (CheckHorizontalLine(grid, centerRow))
                {
                    winningLines++;
                }

                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (CheckHorizontalLine(grid, row))
                    {
                        winningLines++;
                    }
                }

                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (CheckVerticalLine(grid, column))
                    {
                        winningLines++;
                    }
                }

                if (CheckDiagonalTopLeft(grid))
                {
                    winningLines++;
                }

                if (CheckDiagonalTopRight(grid))
                {
                    winningLines++;
                }

                break;

            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        decimal winnings = winningLines * PAYOUT_PER_LINE;

        money += winnings;

        Console.WriteLine();

        if (winningLines > 0)
        {
            Console.WriteLine($"You won {winningLines} line(s)!");
            Console.WriteLine($"Winnings: ${winnings}");
        }
        else
        {
            Console.WriteLine("No winning lines.");
        }

        Console.WriteLine($"You now have ${money}");
    }

    static bool CheckHorizontalLine(int[,] grid, int row)
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

    static bool CheckVerticalLine(int[,] grid, int column)
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

    static bool CheckDiagonalTopLeft(int[,] grid)
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

    static bool CheckDiagonalTopRight(int[,] grid)
    {
        int lastIndex = grid.GetLength(0) - 1;

        int firstNumber = grid[0, lastIndex];

        for (int i = 1; i < grid.GetLength(0); i++)
        {
            if (grid[i, i] != firstNumber)
            {
                return false;
            }
        }

        return true;
    }
}