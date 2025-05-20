namespace MrBowling;

public class Bowling
{
    public void UdregningAfKast(int[,] scoreBoard, int[] sum, int runde)
    {
        sum[runde] += scoreBoard[runde, 0] + scoreBoard[runde, 1];
        if (runde != 0)
        {
            sum[runde] += sum[runde - 1];
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
        
        if (runde != førsteRunde && scoreBoard[runde - forrigeRunde, førsteKast] + scoreBoard[runde - forrigeRunde, andetKast] == sparePointe && scoreBoard[runde - forrigeRunde, førsteKast] != strikePointe)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, førsteKast];
        }
        else if (runde != førsteRunde && scoreBoard[runde - forrigeRunde, førsteKast] + scoreBoard[runde - forrigeRunde, andetKast] == sparePointe && scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe)
        {
            
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
        else if (runde != førsteRunde && kast == andetKast && scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe)
        {
            sum[runde - forrigeRunde] += scoreBoard[runde, andetKast];
        }
        else if (runde != førsteRunde && kast == førsteKast && scoreBoard[runde - forrigeRunde, førsteKast] + scoreBoard[runde - forrigeRunde, andetKast] == sparePointe && scoreBoard[runde, førsteKast] == strikePointe)
        {
            sum[runde + 0] += 10;
        }

        if (runde > andenRunde && kast == førsteKast && scoreBoard[runde - forrigeRunde, førsteKast] == strikePointe && scoreBoard[runde - førForrigeRunde, førsteKast] == strikePointe)
        {
            sum[runde - førForrigeRunde] += scoreBoard[runde, førsteKast];
            sum[runde - forrigeRunde] += scoreBoard[runde, førsteKast];
        }
    }
}