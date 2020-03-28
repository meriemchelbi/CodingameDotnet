using Codingame;
using Codingame.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingameTests
{
    public class OutputGeneratorTests
    {
        [Theory]
        [InlineData("Solo action", "Solo action")]
        [InlineData("Action 1 | Action 2", "Action 1", "Action 2")]
        public void ConstructGameOutputGeneratesExpectedString(string expectedOutput, params string[] action)
        {
            var gameState = new GameState();
            var playerActions = new PlayerActions(gameState);
            playerActions.Actions.AddRange(action);
            var sut = new OutputGenerator(gameState, playerActions);

            sut.OutputActions();

            sut.GameOutput.Should().Be(expectedOutput);
        }

        [Fact]
        public void ConstructGameStateGeneratesExpectedOutput()
        {
            var gameState = new GameState()
            {
                // populate gamestate
            };
            var playerActions = new PlayerActions(gameState);
            var sut = new OutputGenerator(gameState, playerActions);
            var expectedOutput = "wobble"; // update this value

            sut.DisplayGameState();

            sut.GameStateOutput.Should().Be(expectedOutput);
        }
    }
}
