namespace MrBowling;

public class Bowling
{
    public void UdregningAfKast(int[,] scoreBoard, int[] sumAfRunde, int runde)
    {
        sumAfRunde[runde] += scoreBoard[runde, 0] + scoreBoard[runde, 1];
        if (runde != 0)
        {
            sumAfRunde[runde] += sumAfRunde[runde - 1];
        }
    }

    public void UdregningAfSpare(int[,] scoreBoard, int[] sum, int runde)
    {
        var førsteRunde = 0;
        var andenRunde = 1;
        var førsteKast = 0;
        var andetKast = 1;
        var forrigeRunde = 1;
        var sparePointe = 10;
        var strikePointe = 10;

        if (runde != førsteRunde &&
            scoreBoard[runde - forrigeRunde, førsteKast] + scoreBoard[runde - forrigeRunde, andetKast] == sparePointe &&
            scoreBoard[runde - forrigeRunde, førsteKast] != strikePointe)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, førsteKast];
        }
    }

    public void UdregningAfStrike(int[,] scoreBoard, int runde, int kast, int[] sum)
    {
        var førsteRunde = 0;
        var andenRunde = 1;
        var førsteKast = 0;
        var andetKast = 1;
        var forrigeRunde = 1;
        var førForrigeRunde = 2;
        var sparePointe = 10;
        var strikePointe = 10;

        if (runde != førsteRunde && kast == førsteKast && scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, førsteKast];
        }
        else if (runde != førsteRunde && kast == andetKast &&
                 scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, andetKast];
        }
        else if (runde != førsteRunde && kast == førsteKast &&
                 scoreBoard[runde - forrigeRunde, førsteKast] + scoreBoard[runde - forrigeRunde, andetKast] ==
                 sparePointe && scoreBoard[runde, førsteKast] == strikePointe)
        {
            sum[runde + 0] += 10;
        }

        if (runde > andenRunde && kast == førsteKast && scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe &&
            scoreBoard[runde - førForrigeRunde, førsteKast] == strikePointe)
        {
            sum[runde - førForrigeRunde] += scoreBoard[runde, førsteKast];
            sum[runde - forrigeRunde] += scoreBoard[runde, førsteKast];
        }
    }

    public void UdregningAfSidsteRundeKast(int[,] scoreBoard, int[] sumAfRunde)
    {
        sumAfRunde[9] += scoreBoard[9, 0] + scoreBoard[9, 1] + scoreBoard[9, 2];
        sumAfRunde[9] += sumAfRunde[9 - 1];
    }

    public void UdregningAfSidsteRundeSpare(int[,] scoreBoard, int[] sumAfRunde)
    {
    }

    public void UdregningAfSidsteRundeStrike(int[,] scoreBoard, int kast, int[] sumAfRunde)
    {
        if (scoreBoard[9, kast] == 10 && kast != 0)
        {
            if (scoreBoard[9, kast - 1] == 10)
            {
              sumAfRunde[9] += 10;
            }
        }

        if (scoreBoard[9, kast] == 10 && kast != 0 && kast != 1)
        {
            if (scoreBoard[9, kast - 1] == 10 && scoreBoard[9, kast - 2] == 10)
            {
               sumAfRunde[9] += 10; 
            }
        }
    }
}