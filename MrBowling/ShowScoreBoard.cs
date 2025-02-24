namespace MrBowling;

public class ShowScoreBoard
{
    public string PrintScoreBoard(int[,] scoreBoard, string[,] scoreBoardString, int runde)
    {
        if (scoreBoard[runde, 0] == 10)
        {
            scoreBoardString[runde, 0] = "x";
        }
        else if (scoreBoard[runde, 0] + scoreBoard[runde, 1] == 10)
        {
            scoreBoardString[runde, 1] = "/";
            scoreBoardString[runde, 0] = scoreBoard[runde, 0].ToString();
        }
        else if (scoreBoard[runde, 0] + scoreBoard[runde, 1] != 10)
        {
            scoreBoardString[runde, 0] = scoreBoard[runde, 0].ToString();
            scoreBoardString[runde, 1] = scoreBoard[runde, 1].ToString();
        }


        return
            $"{scoreBoardString[0, 0]} {scoreBoardString[0, 1]}   {scoreBoardString[1, 0]} {scoreBoardString[1, 1]}   " +
            $"{scoreBoardString[2, 0]} {scoreBoardString[2, 1]}   {scoreBoardString[3, 0]} {scoreBoardString[3, 1]}   " +
            $"{scoreBoardString[4, 0]} {scoreBoardString[4, 1]}   {scoreBoardString[5, 0]} {scoreBoardString[5, 1]}   " +
            $"{scoreBoardString[6, 0]} {scoreBoardString[6, 1]}   {scoreBoardString[7, 0]} {scoreBoardString[7, 1]}   " +
            $"{scoreBoardString[8, 0]}  {scoreBoardString[8, 1]}   {scoreBoardString[9, 0]} {scoreBoardString[9, 1]}";
    }

    public string PrintSumAfRunder(int[] sum)
    {
        return $"{sum[0]}    {sum[1]}    {sum[2]}    {sum[3]}    " +
               $"{sum[4]}    {sum[5]}    {sum[6]}    {sum[7]}    " +
               $"{sum[8]}    {sum[9]}";
    }
}