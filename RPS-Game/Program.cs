using System;

namespace RPS_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your name: ");
                string huPlayerName = Console.ReadLine();
                string aiPlayerName = "AIplayer";

                Player humanPlayer = new Player(huPlayerName);
                Player aiPlayer = new Player(aiPlayerName);

                RPSGame game = new RPSGame(humanPlayer, aiPlayer);
                game.PlayGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in the main program: {ex.Message}");
            }
        }
    }
}
