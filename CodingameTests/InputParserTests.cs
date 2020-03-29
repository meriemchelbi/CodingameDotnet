using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class InputParserTests
    {
        [Fact]
        public void LoadGameStateLoadsInitialGameParameters()
        {
            var inputs = new string[] { "3", "3", "0" };
            var lines = new List<string> { "..x", ".x.", "x..", };
            var gameState = new GameState();
            var analyser = new FrequencyAnalyser(gameState);
            var sut = new InputParser(gameState, inputs, lines, analyser);
            var expectedMap = new Cell[,]
            {
                { new Cell(".", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell(".", 1, 0), new Cell("x", 1, 1), new Cell(".", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell(".", 2, 2) }
            };

            sut.LoadGameState();

            gameState.MapHeight.Should().Be(3);
            gameState.MapWidth.Should().Be(3);
            gameState.PlayerStartsFirst.Should().BeTrue();
            gameState.CellMap.Should().BeEquivalentTo(expectedMap);
        }

        [Fact]
        public void UpdateGameStateLoadsLatestGameParameters()
        {
            var inputs = new string[] { "4", "5", "3", "2" };
            var opponentOrders = "Wibble";
            var lines = new List<string>();
            var gameState = new GameState();
            var analyser = new FrequencyAnalyser(gameState);
            var sut = new InputParser(gameState, inputs, lines, analyser);
            
            sut.UpdateGameState(inputs, opponentOrders);

            gameState.MyCoordinates.Should().BeEquivalentTo(new Cell(4, 5));
            gameState.MyLife.Should().Be(3);
            gameState.OpponentLife.Should().Be(2);
            gameState.OpponentOrders.Should().Be("Wibble");
        }
    }
}
