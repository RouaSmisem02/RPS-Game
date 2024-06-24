using System;

namespace RPS_Game
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public string ChooseMove()
        {
            string move = string.Empty;
            while (move != "rock" && move != "paper" && move != "scissors")
            {
                try
                {
                    Console.Write($"{Name}, enter your move (rock, paper, or scissors): ");
                    move = Console.ReadLine().ToLower();
                    if (move != "rock" && move != "paper" && move != "scissors")
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while choosing a move: {ex.Message}");
                }
            }
            return move;
        }
    }
}
