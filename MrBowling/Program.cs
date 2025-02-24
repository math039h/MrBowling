using System;
using MrBowling;

Console.WriteLine("Velkommen til Bowling!");
Console.WriteLine("Indtast spillernavn:");
var input = Console.ReadLine();

int[,] scoreBoard =
    { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };

string[,] scoreBoardString =
{
    { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" }, { "0", "0" },
    { "0", "0" }, { "0", "0" }, { "0", "0" }
};
int[] sum =
    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 2; j++)
    {
        Console.WriteLine(input + "´s tur til at kaste");
        var inputKast = Int32.Parse(Console.ReadLine());
        Console.WriteLine(input + " har scoret " + inputKast + " i kast nr " + (j + 1));

        scoreBoard[i, j] = inputKast;
    }

    var bowling = new Bowling();
    bowling.UdregningAfKast(scoreBoard, sum, i);
    bowling.UdregningAfSpare(scoreBoard, sum, i);

    var showScoreBoard = new ShowScoreBoard();

    Console.WriteLine(showScoreBoard.PrintScoreBoard(scoreBoard, scoreBoardString, i));
    Console.WriteLine(showScoreBoard.PrintSumAfRunder(sum));
}