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
            bool continuePlaying = true;

            while (continuePlaying)
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

                // Ask user if they want to continue playing
                Console.Write("Do you want to play another game? (yes/no): ");
                string playAgainResponse = Console.ReadLine().ToLower();

                if (playAgainResponse != "yes")
                {
                    continuePlaying = false;
                }
                else
                {
                    // Reset scores for a new game
                    humanPlayer.Score = 0;
                    aiPlayer.Score = 0;
                    Console.WriteLine("\nStarting a new game!\n");
                }
            }

            Console.WriteLine("Thank you for playing!");
        }

        private string GetAIMove()
        {
            string[] moves = { "rock", "paper", "scissors" };
            int index = random.Next(moves.Length);
            return moves[index];
        }

        public void DetermineWinner(string humanMove, string aiMove)
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

        private void DisplayScores()
        {
            Console.WriteLine($"{humanPlayer.Name}: {humanPlayer.Score} - {aiPlayer.Name}: {aiPlayer.Score}");
        }

        private void DeclareWinner()
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
                    `""""""""""`");
            }
            else
            {
                Console.WriteLine("The game is a tie!");
            }
        }
    }
}
