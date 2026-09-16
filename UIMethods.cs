namespace SlotMachine;

public class UIMethods
{
    const int CENTRE_HORIZONTAL = 1;
    const int ALL_HORIZONTAL = 2;
    const int ALL_VERTICAL = 3;
    const int BOTH_DIAGONALS = 4;
    const int ALL_LINES = 5;
    
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
    
    public static void PrintPlayerInitialAmount(decimal amount)
    {
        Console.WriteLine($"You have £{amount}");
    }

    public static decimal GetPlayerWagerAmount()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal wagerAmount))
            {
                if (wagerAmount >= 0)
                {
                    return wagerAmount;
                }
            }

            Console.WriteLine("Please enter a valid wager amount.");
        }
    }

    public static void PrintLinesToPlay()
    {
        Console.WriteLine("Chose which lines to play:");
        Console.WriteLine();
        Console.WriteLine($"{CENTRE_HORIZONTAL}. Centre horizontal");
        Console.WriteLine($"{ALL_HORIZONTAL}. All horizontal");
        Console.WriteLine($"{ALL_VERTICAL}. All vertical");
        Console.WriteLine($"{BOTH_DIAGONALS}. Both diagonals");
        Console.WriteLine($"{ALL_LINES}. All lines");
    }

    public static int GetDimension(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int dimension))
            {
                if (dimension > 0)
                {
                    return dimension;
                }
            }

            Console.WriteLine("Please enter a positive number.");
        }
    }

    public static int GetPlayerChoice()
    {
        return int.Parse(Console.ReadLine());
        ;
    }

    public static void PrintPlayerWagerPrompt()
    {
        Console.Write("Enter your wager: ");
    }

    public static void ApplyLineSeperator()
    {
        Console.WriteLine();
    }

    public static void PrintPlayerHasInsufficientFunds()
    {
        Console.WriteLine("You don't have enough money.");
    }

    public static void PrintPlayerSpinAlertMessage()
    {
        Console.WriteLine("Here is your spin:");
    }

    public static void PrintInvalidChoiceMessage()
    {
        Console.WriteLine("Invalid choice.");
    }

    public static void PrintPlayerWinningLines(int winningLines)
    {
        Console.WriteLine($"You won {winningLines} line(s)!");
    }

    public static void PrintPlayerWinnings(decimal winnings)
    {
        Console.WriteLine($"Winnings: ${winnings}");
    }

    public static void PrintNoWinningLines()
    {
        Console.WriteLine("No winning lines.");
    }

    public static void PrintBalance(decimal balance)
    {
        Console.WriteLine($"You now have ${balance}");
    }
}