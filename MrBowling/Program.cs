using System;
using MrBowling;

Console.WriteLine("Velkommen til Bowling!");
Console.WriteLine("Indtast spillernavn:");
var input = Console.ReadLine();

int[,] scoreBoard =
    { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

string[,] scoreBoardString =
{
    { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" },
    { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "0" }
};
int[] sumAfRunde =
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

const int sidsteRunde = 9;

for (int i = 0; i < 10; i++)
{
    var bowling = new Bowling();

    for (int j = 0; j < 3; j++)
    {
        if (j == 2 && i != 9 || j == 1 && scoreBoard[i, j - 1] == 10 && i != 9 )
        {
        }
        else if (scoreBoardString[9, 0] != "X" || scoreBoardString[9, 1] != "/")
        {
            Console.WriteLine(input + "´s tur til at kaste");
            var inputKast = Int32.Parse(Console.ReadLine());
            Console.WriteLine(input + " har scoret " + inputKast + " i kast nr " + (j + 1));

            scoreBoard[i, j] = inputKast;

            if (i != sidsteRunde)
            {
                bowling.UdregningAfStrike(scoreBoard, i, j, sumAfRunde);
            }
            else
            {
                bowling.UdregningAfSidsteRundeStrike(scoreBoard, j, sumAfRunde);
                bowling.UdregningAfSidsteRundeSpare(scoreBoard, j, sumAfRunde);
            }
        }
    }


    if (i != sidsteRunde)
    {
        bowling.UdregningAfKast(scoreBoard, sumAfRunde, i);
        bowling.UdregningAfSpare(scoreBoard, sumAfRunde, i);
    }
    else if (scoreBoard[sidsteRunde, 0] + scoreBoard[sidsteRunde, 1] == 10)
    {
        
    }

    if (i == sidsteRunde /*&& scoreBoard[sidsteRunde, 0] == 10 || scoreBoard[sidsteRunde, 1] == 10 || scoreBoard[sidsteRunde, 2] == 10*/)
    {
        bowling.UdregningAfSidsteRundeKast(scoreBoard, sumAfRunde);
    }
    

    var showScoreBoard = new ShowScoreBoard();

    Console.WriteLine(showScoreBoard.PrintScoreBoard(scoreBoard, scoreBoardString, i));
    Console.WriteLine(showScoreBoard.PrintSumAfRunder(sumAfRunde));
}