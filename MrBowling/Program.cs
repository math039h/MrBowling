using MrBowling;

Console.WriteLine("Velkommen til Bowling!");
Console.WriteLine("Indtast spillernavn:");
var input = Console.ReadLine();

var scoreBoard = new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

var scoreBoardString = new[,] {
    { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "" },
    { "0", "0", "" }, { "0", "0", "" }, { "0", "0", "0" }
};
int[] sumAfRunde =
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

const int sidsteRunde = 9;
const int førsteKast = 0;
const int andetKast = 1;
const int tredjeKast = 2;
const int maxPointe = 10;

for (var runde = 0; runde < 10; runde++)
{
    for (var kast = førsteKast; kast < 3; kast++)
    {
        var forrigeKast = kast - 1;
        
        if (kast == tredjeKast && runde != sidsteRunde || kast == andetKast && scoreBoard[runde, forrigeKast] == maxPointe && runde != sidsteRunde)
        {
            //This exists to skip every third execution
        }
        else if (scoreBoardString[sidsteRunde, førsteKast] != "X" || scoreBoardString[sidsteRunde, andetKast] != "/")
        {
            Console.WriteLine(input + "´s tur til at kaste");
            var inputKast = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine($"{input} har scoret {inputKast} i kast nr {kast + 1}");

            scoreBoard[runde, kast] = inputKast;

            if (runde != sidsteRunde)
            {
                Bowling.UdregningAfStrike(scoreBoard, runde, kast, sumAfRunde);
            }
            else
            {
                Bowling.UdregningAfSidsteRundeStrike(scoreBoard, kast, sumAfRunde);
                Bowling.UdregningAfSidsteRundeSpare(scoreBoard, kast, sumAfRunde);
            }
        }
    }

    if (runde != sidsteRunde)
    {
        Bowling.UdregningAfKast(scoreBoard, sumAfRunde, runde);
        Bowling.UdregningAfSpare(scoreBoard, sumAfRunde, runde);
    }

    if (runde == sidsteRunde)
    {
        Bowling.UdregningAfSidsteRundeKast(scoreBoard, sumAfRunde);
    }

    var showScoreBoard = new ShowScoreBoard();

    Console.WriteLine(ShowScoreBoard.PrintScoreBoard(scoreBoard, scoreBoardString, runde));
    Console.WriteLine(ShowScoreBoard.PrintSumAfRunder(sumAfRunde));
}