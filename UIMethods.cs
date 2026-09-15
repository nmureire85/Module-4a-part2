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

    public static void PrintLinesToPlayer()
    {
        Console.WriteLine("Chose which lines to play:");
        Console.WriteLine();
        Console.WriteLine("1. Centre horizontal");
        Console.WriteLine("2. All horizontal");
        Console.WriteLine("3. All vertical");
        Console.WriteLine("4. Both diagonals");
        Console.WriteLine("5. All lines");
    }

    public static int GetRowDimension(int row)
    {
        Console.WriteLine("Enter row dimension for your grid");
        return row;
    }

    public static int GetColumnDimension(int column)
    {
        Console.WriteLine("Enter column dimension for your grid");
        return column;
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