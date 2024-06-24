using System;
using Xunit;

namespace RPS_Game.Tests
{
    public class RPSGameTests
    {
        [Fact]
        public void TestDetermineWinner_HumanWins()
        {
            // Arrange
            Player human = new Player("Human");
            Player ai = new Player("AI");
            RPSGame game = new RPSGame(human, ai);

            // Act
            game.DetermineWinner("rock", "scissors");

            // Assert
            Assert.Equal(1, human.Score);
            Assert.Equal(0, ai.Score);
        }

        [Fact]
        public void TestDetermineWinner_AIWins()
        {
            // Arrange
            Player human = new Player("Human");
            Player ai = new Player("AI");
            RPSGame game = new RPSGame(human, ai);

            // Act
            game.DetermineWinner("rock", "paper");

            // Assert
            Assert.Equal(0, human.Score);
            Assert.Equal(1, ai.Score);
        }

        [Fact]
        public void TestDetermineWinner_Tie()
        {
            // Arrange
            Player human = new Player("Human");
            Player ai = new Player("AI");
            RPSGame game = new RPSGame(human, ai);

            // Act
            game.DetermineWinner("rock", "rock");

            // Assert
            Assert.Equal(0, human.Score);
            Assert.Equal(0, ai.Score);
        }
    }
}
