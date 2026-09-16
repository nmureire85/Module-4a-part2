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
        Random random = new Random();

        decimal money = STARTING_MONEY;
        UIMethods.PrintPlayerInitialAmount(money);
        UIMethods.PrintPlayerWagerPrompt();
        decimal wager = UIMethods.GetPlayerWagerAmount();
        if (wager > money)
        {
            UIMethods.PrintPlayerHasInsufficientFunds();
            return;
        }

        UIMethods.ApplyLineSeperator();
        UIMethods.PrintLinesToPlay();
        int choice = UIMethods.GetPlayerChoice();

        money -= wager;

        int rows = UIMethods.GetDimension("Enter row dimension for your grid: ");
        int columns = UIMethods.GetDimension("Enter column dimension for your grid: ");

        UIMethods.ApplyLineSeperator();
        int[,] grid = SlotMachineActions.CreateGrid(rows, columns, random);

        UIMethods.ApplyLineSeperator();
        UIMethods.PrintPlayerSpinAlertMessage();
        UIMethods.DisplayGrid(grid);
        int winningLines = 0;

        switch (choice)
        {
            case 1:
                winningLines = SlotMachineActions.CheckCenterHorizontalLineWinnings(grid, winningLines);

                break;

            case 2:
                winningLines = SlotMachineActions.CheckHorizontalLineWinnings(grid, winningLines);

                break;

            case 3:
                winningLines = SlotMachineActions.CheckVerticalLineWinnings(grid, winningLines);

                break;

            case 4:
                winningLines = SlotMachineActions.CheckDiagonalTopLeftWinnings(grid, winningLines);

                winningLines = SlotMachineActions.CheckDiagonalTopRightWinnings(grid, winningLines);

                break;

            case 5:

                winningLines = SlotMachineActions.CheckCenterHorizontalLineWinnings(grid, winningLines);
                
                winningLines = SlotMachineActions.CheckHorizontalLineWinnings(grid, winningLines);

                winningLines = SlotMachineActions.CheckVerticalLineWinnings(grid, winningLines);

                winningLines = SlotMachineActions.CheckDiagonalTopLeftWinnings(grid, winningLines);

                winningLines = SlotMachineActions.CheckDiagonalTopRightWinnings(grid, winningLines);

                break;

            default:
                UIMethods.PrintInvalidChoiceMessage();
                return;
        }

        decimal winnings = winningLines * PAYOUT_PER_LINE;

        money += winnings;
        if (winningLines > 0)
        {
            UIMethods.PrintPlayerWinningLines(winningLines);
            UIMethods.PrintPlayerWinnings(winnings);
        }
        else
        {
            UIMethods.PrintNoWinningLines();
        }

        UIMethods.PrintBalance(money);
    }
}