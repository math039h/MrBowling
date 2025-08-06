namespace MrBowling;

public static class Bowling
{
    private const int FørsteKast = 0;
    private const int AndetKast = 1;
    private const int TredjeKast = 2;
    private const int FørsteRunde = 0;
    private const int AndenRunde = 1;
    private const int SidsteRunde = 9;
    private const int MaxPoints = 10;
    
    public static void UdregningAfKast(int[,] scoreBoard, int[] sumAfRunde, int runde)
    {
        var forrigeRunde = runde - 1;
        sumAfRunde[runde] += scoreBoard[runde, FørsteKast] + scoreBoard[runde, AndetKast];
        
        if (runde != FørsteRunde)
        {
            sumAfRunde[runde] += sumAfRunde[forrigeRunde];
        }
    }
    
    public static void UdregningAfSpare(int[,] scoreBoard, int[] sumAfRunde, int runde)
    {
        var forrigeRunde = runde - 1;

        if (runde == FørsteRunde ||
            scoreBoard[runde - forrigeRunde, FørsteKast] + scoreBoard[runde - forrigeRunde, AndetKast] != MaxPoints ||
            scoreBoard[runde - forrigeRunde, FørsteKast] == MaxPoints) 
            return;
        
        sumAfRunde[runde - forrigeRunde] += scoreBoard[runde, FørsteKast];
        sumAfRunde[runde] += scoreBoard[runde, FørsteKast];
    }

    public static void UdregningAfStrike(int[,] scoreBoard, int runde, int kast, int[] sum)
    {
        var forrigeRunde = runde - 1;
        var førForrigeRunde = runde - 2;

        if (runde != FørsteRunde && kast == FørsteKast && scoreBoard[runde - forrigeRunde, FørsteKast] == MaxPoints)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, FørsteKast];
        }
        else if (runde != FørsteRunde && kast == AndetKast &&
                 scoreBoard[runde - forrigeRunde, FørsteKast] == MaxPoints)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, AndetKast];
        }
        else if (runde != FørsteRunde && kast == FørsteKast &&
                 scoreBoard[runde - forrigeRunde, FørsteKast] + scoreBoard[runde - forrigeRunde, AndetKast] ==
                 MaxPoints && scoreBoard[runde, FørsteKast] == MaxPoints)
        {
            sum[runde] += MaxPoints;
        }

        if (runde <= AndenRunde || kast != FørsteKast || scoreBoard[runde - forrigeRunde, FørsteKast] != MaxPoints ||
            scoreBoard[førForrigeRunde, FørsteKast] != MaxPoints) 
            return;
        
        sum[førForrigeRunde] += scoreBoard[runde, FørsteKast];
        sum[runde - forrigeRunde] += scoreBoard[runde, FørsteKast];
    }

    public static void UdregningAfSidsteRundeKast(int[,] scoreBoard, int[] sumAfRunde)
    {
        const int forrigeRunde = SidsteRunde - 1;
        sumAfRunde[SidsteRunde] += scoreBoard[SidsteRunde, FørsteKast] + scoreBoard[SidsteRunde, AndetKast] + scoreBoard[SidsteRunde, TredjeKast];
        sumAfRunde[SidsteRunde] += sumAfRunde[forrigeRunde];
    }

    public static void UdregningAfSidsteRundeSpare(int[,] scoreBoard, int kast, int[] sumAfRunde)
    {
        const int forrigeRunde = SidsteRunde - 1;
        
        if (scoreBoard[SidsteRunde, FørsteKast] + scoreBoard[SidsteRunde, AndetKast] == MaxPoints && scoreBoard[SidsteRunde, AndetKast] != MaxPoints && kast == TredjeKast)
        {
            sumAfRunde[SidsteRunde] += scoreBoard[SidsteRunde, TredjeKast];
        }

        if (scoreBoard[forrigeRunde, FørsteKast] + scoreBoard[forrigeRunde, AndetKast] == MaxPoints && kast == FørsteKast)
        {
            sumAfRunde[forrigeRunde] += scoreBoard[SidsteRunde, FørsteKast];
        }
    }

    public static void UdregningAfSidsteRundeStrike(int[,] scoreBoard, int kast, int[] sumAfRunde)
    {
        const int forrigeRunde = SidsteRunde - 1;
        const int førForrigeRunde = SidsteRunde - 2;
        var forrigeKast = kast - 1;
        var førForrigeKast = kast - 2;
        
        if (scoreBoard[SidsteRunde, kast] == MaxPoints && kast != FørsteKast)
        {
            if (scoreBoard[SidsteRunde, forrigeKast] == MaxPoints)
            {
                sumAfRunde[SidsteRunde] += MaxPoints;
            }
        }

        if (scoreBoard[SidsteRunde, kast] == MaxPoints && kast != FørsteKast && kast != AndetKast)
        {
            if (scoreBoard[SidsteRunde, forrigeKast] == MaxPoints && scoreBoard[SidsteRunde, førForrigeKast] == MaxPoints)
            {
                sumAfRunde[SidsteRunde] += MaxPoints;
            }
        }

        if (scoreBoard[SidsteRunde, FørsteKast] == MaxPoints && scoreBoard[forrigeRunde, FørsteKast] == MaxPoints && kast == FørsteKast)
        {
            sumAfRunde[forrigeRunde] += MaxPoints;
        }

        if (scoreBoard[SidsteRunde, FørsteKast] == MaxPoints && scoreBoard[forrigeRunde, FørsteKast] == MaxPoints && scoreBoard[førForrigeRunde, FørsteKast] == MaxPoints && kast == FørsteKast)
        {
            sumAfRunde[førForrigeRunde] += MaxPoints;
        }

        if (scoreBoard[SidsteRunde, FørsteKast] == MaxPoints && scoreBoard[SidsteRunde, AndetKast] == MaxPoints && scoreBoard[forrigeRunde, FørsteKast] == MaxPoints && kast == AndetKast)
        {
            sumAfRunde[forrigeRunde] += MaxPoints;
        }
    }
}