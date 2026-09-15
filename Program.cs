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
        UIMethods.PrintLinesToPlayer();
        int choice = UIMethods.GetPlayerChoice();

        money -= wager;

        int rows = UIMethods.GetRowDimension(5);
        int columns = UIMethods.GetColumnDimension(5);

        UIMethods.ApplyLineSeperator();
        int[,] grid = SlotMachineActions.CreateGrid(rows, columns, random);

        UIMethods.ApplyLineSeperator();
        UIMethods.PrintPlayerSpinAlertMessage();
        SlotMachineActions.DisplayGrid(grid);
        int winningLines = 0;

        switch (choice)
        {
            case 1:
                int centerRow = grid.GetLength(0) / 2;
                if (SlotMachineActions.CheckHorizontalLine(grid, centerRow))
                {
                    winningLines++;
                }

                break;

            case 2:
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (SlotMachineActions.CheckHorizontalLine(grid, row))
                    {
                        winningLines++;
                    }
                }

                break;

            case 3:
                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (SlotMachineActions.CheckVerticalLine(grid, column))
                    {
                        winningLines++;
                    }
                }

                break;

            case 4:
                if (SlotMachineActions.CheckDiagonalTopLeft(grid))
                {
                    winningLines++;
                }

                if (SlotMachineActions.CheckDiagonalTopRight(grid))
                {
                    winningLines++;
                }

                break;

            case 5:

                centerRow = grid.GetLength(0) / 2;
                if (SlotMachineActions.CheckHorizontalLine(grid, centerRow))
                {
                    winningLines++;
                }

                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    if (SlotMachineActions.CheckHorizontalLine(grid, row))
                    {
                        winningLines++;
                    }
                }

                for (int column = 0; column < grid.GetLength(1); column++)
                {
                    if (SlotMachineActions.CheckVerticalLine(grid, column))
                    {
                        winningLines++;
                    }
                }

                if (SlotMachineActions.CheckDiagonalTopLeft(grid))
                {
                    winningLines++;
                }

                if (SlotMachineActions.CheckDiagonalTopRight(grid))
                {
                    winningLines++;
                }

                break;

            default:
                UIMethods.PrintInvalidChoiceMessage();
                return;
        }

        decimal winnings = winningLines * PAYOUT_PER_LINE;

        money += winnings;

        UIMethods.PrintLinesToPlayer();
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