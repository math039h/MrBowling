namespace MrBowling;

public class ShowScoreBoard
{
    public static string PrintScoreBoard(int[,] scoreBoard, string[,] scoreBoardString, int runde)
    {
        const int førsteKast = 0;
        const int andetKast = 1;
        const int tredjeKast = 2;
        const int maxPointe = 10;
        const int sidsteRunde = 9;

        if (runde != sidsteRunde)
        {
            if (scoreBoard[runde, førsteKast] == maxPointe)
            {
                scoreBoardString[runde, førsteKast] = "X";
            }
            else if (scoreBoard[runde, førsteKast] + scoreBoard[runde, andetKast] == maxPointe )
            {
                scoreBoardString[runde, andetKast] = "/";
                scoreBoardString[runde, førsteKast] = scoreBoard[runde, førsteKast].ToString();
            }
            else if (scoreBoard[runde, førsteKast] + scoreBoard[runde, andetKast] != maxPointe)
            {
                scoreBoardString[runde, førsteKast] = scoreBoard[runde, førsteKast].ToString();
                scoreBoardString[runde, andetKast] = scoreBoard[runde, andetKast].ToString();
            }
        }
        else
        {
            scoreBoardString[runde, førsteKast] = scoreBoard[runde, førsteKast].ToString();
            scoreBoardString[runde, andetKast] = scoreBoard[runde, andetKast].ToString();
            scoreBoardString[runde, tredjeKast] = scoreBoard[runde, tredjeKast].ToString();

            if (scoreBoard[sidsteRunde, førsteKast] == maxPointe)
            {
                scoreBoardString[sidsteRunde, førsteKast] = "X";
            }

            if (scoreBoard[sidsteRunde, andetKast] == maxPointe)
            {
                scoreBoardString[sidsteRunde, andetKast] = "X";
            }

            if (scoreBoard[sidsteRunde, tredjeKast] == maxPointe)
            {
                scoreBoardString[sidsteRunde, tredjeKast] = "X";
            }
            
            if (scoreBoard[runde, førsteKast] + scoreBoard[runde, andetKast] == maxPointe )
            {
                scoreBoardString[runde, andetKast] = "/";
                scoreBoardString[runde, førsteKast] = scoreBoard[runde, førsteKast].ToString();
            }
        }

        return
            $"{scoreBoardString[0, 0]} {scoreBoardString[0, 1]}   {scoreBoardString[1, 0]} {scoreBoardString[1, 1]}   " +
            $"{scoreBoardString[2, 0]} {scoreBoardString[2, 1]}   {scoreBoardString[3, 0]} {scoreBoardString[3, 1]}   " +
            $"{scoreBoardString[4, 0]} {scoreBoardString[4, 1]}   {scoreBoardString[5, 0]} {scoreBoardString[5, 1]}   " +
            $"{scoreBoardString[6, 0]} {scoreBoardString[6, 1]}   {scoreBoardString[7, 0]} {scoreBoardString[7, 1]}   " +
            $"{scoreBoardString[8, 0]} {scoreBoardString[8, 1]}   {scoreBoardString[9, 0]} {scoreBoardString[9, 1]} {scoreBoardString[9, 2]}";
    }

    public static string PrintSumAfRunder(int[] sum)
    {
        return $"{sum[0]}    {sum[1]}    {sum[2]}    {sum[3]}    " +
               $"{sum[4]}    {sum[5]}    {sum[6]}    {sum[7]}    " +
               $"{sum[8]}    {sum[9]}";
    }
}