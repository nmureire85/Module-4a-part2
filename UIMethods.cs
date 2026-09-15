namespace SlotMachine;

public class UIMethods
{
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
        Console.WriteLine("1. Centre horizontal");
        Console.WriteLine("2. All horizontal");
        Console.WriteLine("3. All vertical");
        Console.WriteLine("4. Both diagonals");
        Console.WriteLine("5. All lines");
    }

    public static int GetRowDimension()
    {
        while (true)
        {
            Console.Write("Enter row dimension for your grid: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int rows))
            {
                if (rows > 0)
                {
                    return rows;
                }
            }

            Console.WriteLine("Please enter a positive number.");
        }
    }
    
    public static int GetColumnDimension()
    {
        while (true)
        {
            Console.Write("Enter column dimension for your grid: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int column))
            {
                if (column > 0)
                {
                    return column;
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