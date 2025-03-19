namespace MrBowling;

public class Bowling
{
    public void UdregningAfKast(int[,] scoreBoard, int[] sum, int runde)
    {
        sum[runde] = scoreBoard[runde, 0] + scoreBoard[runde, 1];
        if (runde != 0)
        {
            sum[runde] += sum[runde - 1];
        }
    }
    
    public void UdregningAfSpare(int[,] scoreBoard, int[] sum, int runde)
    {
        if (runde != 0 && scoreBoard[runde - 1, 0] + scoreBoard[runde - 1, 1] == 10 && scoreBoard[runde - 1, 0] != 10)
        {
            sum[runde - 1] += scoreBoard[runde, 0];
        }
    }

    public void UdregningAfStrike(int[,] scoreBoard, int runde, int kast, int[] sum)
    {
        if (runde != 0 && kast == 0 && scoreBoard[runde - 1, 0] == 10)
        {
            sum[runde - 1] += scoreBoard[runde, 0];
        }
        else if (runde != 0 && kast == 1 && scoreBoard[runde - 1, 0] == 10)
        {
            sum[runde - 1] += scoreBoard[runde, 1];
        }

        if (runde > 1 && kast == 0 && scoreBoard[runde - 1, 0] == 10 && scoreBoard[runde - 2, 0] == 10)
        {
            sum[runde - 2] += scoreBoard[runde, 0];
        }
    }
}