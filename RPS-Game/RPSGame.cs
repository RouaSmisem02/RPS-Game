using System;

namespace RPS_Game
{
    public class RPSGame
    {
        private Player humanPlayer;
        private Player aiPlayer;
        private Random random;

        public RPSGame(Player human, Player ai)
        {
            humanPlayer = human;
            aiPlayer = ai;
            random = new Random();
        }

        public void PlayGame()
        {
            int rounds = 0;
            while (rounds < 3)
            {
                try
                {
                    string humanMove = humanPlayer.ChooseMove();
                    string aiMove = GetAIMove();
                    Console.WriteLine($"{aiPlayer.Name} chose {aiMove}");
                    DetermineWinner(humanMove, aiMove);
                    rounds++;
                    DisplayScores();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during the game: {ex.Message}");
                }
            }
            DeclareWinner(); // Call to declare the winner after 3 rounds
        }

        private string GetAIMove()
        {
            try
            {
                string[] moves = { "rock", "paper", "scissors" };
                int index = random.Next(moves.Length);
                return moves[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while generating AI move: {ex.Message}");
                return "rock";
            }
        }

        public void DetermineWinner(string humanMove, string aiMove)
        {
            try
            {
                if (humanMove == aiMove)
                {
                    Console.WriteLine("It's a tie!");
                }
                else if ((humanMove == "rock" && aiMove == "scissors") ||
                         (humanMove == "paper" && aiMove == "rock") ||
                         (humanMove == "scissors" && aiMove == "paper"))
                {
                    Console.WriteLine($"{humanPlayer.Name} wins this round!");
                    humanPlayer.Score++;
                }
                else
                {
                    Console.WriteLine($"{aiPlayer.Name} wins this round!");
                    aiPlayer.Score++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while determining the winner: {ex.Message}");
            }
        }

        private void DisplayScores()
        {
            try
            {
                Console.WriteLine($"{humanPlayer.Name}: {humanPlayer.Score} - {aiPlayer.Name}: {aiPlayer.Score}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while displaying scores: {ex.Message}");
            }
        }

        private void DeclareWinner()
        {
            try
            {
                if (humanPlayer.Score > aiPlayer.Score)
                {
                    Console.WriteLine($"{humanPlayer.Name} wins the game!");
                    Console.WriteLine($@"
                           ___________
                          '._==_==_=_.'
                          .-\:      /-.
                         | (|:.     |) |
                          '-|:.     |-'
                            \::.    /
                             '::. .'
                               ) (
                             _.' '._
                            `""{humanPlayer.Name}""`");
                }
                else if (aiPlayer.Score > humanPlayer.Score)
                {
                    Console.WriteLine($"{aiPlayer.Name} wins the game!");
                    Console.WriteLine(@"
                           ___________
                          '._==_==_=_.'
                          .-\:      /-.
                         | (|:.     |) |
                          '-|:.     |-'
                            \::.    /
                             '::. .'
                               ) (
                             _.' '._
                            `""""""""""`");
                                    }
                else
                {
                    Console.WriteLine("The game is a tie!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while declaring the winner: {ex.Message}");
            }
        }
    }
}
