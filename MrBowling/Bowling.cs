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
        if (runde != 0 && scoreBoard[runde - 1, 0] + scoreBoard[runde - 1, 1] == 10)
        {
            sum[runde - 1] += scoreBoard[runde, 0];
        }
    }

    public void UdregningAfStrike(int[,] scoreBoard, int[] sum, int runde)
    {
        // if (runde != 0 && scoreBoard[runde - 1, 0] + scoreBoard[runde - 1, 1] == 10)
        // {
        //     sum[runde - 1] += scoreBoard[runde, 0];
        // }
    }
}