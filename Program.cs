namespace BowlingGameCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            BowlingGame myGame = new BowlingGame();            
            int gameScore = myGame.ScoreGame();

            Console.WriteLine("Final score is " + gameScore.ToString());
            Console.ReadLine();
        }
    }
}