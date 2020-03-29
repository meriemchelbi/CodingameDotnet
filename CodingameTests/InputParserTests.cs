using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class InputParserTests
    {
        private readonly GameState _gameState;
        private FrequencyAnalyser _analyser;

        public InputParserTests()
        {
            _gameState = new GameState();
            _analyser = new FrequencyAnalyser(_gameState);
        }

        [Fact]
        public void LoadGameStateLoadsInitialGameParameters()
        {
            var inputs = new string[] { "3", "3", "0" };
            var lines = new List<string> { "..x", ".x.", "x..", };
            var sut = new InputParser(_gameState, inputs, lines, _analyser);
            var expectedMap = new Cell[,]
            {
                { new Cell(".", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell(".", 1, 0), new Cell("x", 1, 1), new Cell(".", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell(".", 2, 2) }
            };

            sut.LoadGameState();

            _gameState.MapHeight.Should().Be(3);
            _gameState.MapWidth.Should().Be(3);
            _gameState.PlayerStartsFirst.Should().BeTrue();
            _gameState.CellMap.Should().BeEquivalentTo(expectedMap);
        }

        [Fact]
        public void UpdateGameStateLoadsLatestGameParameters()
        {
            var inputs = new string[] { "4", "5", "3", "2" };
            var opponentOrders = "Wibble";
            var lines = new List<string>();
            var sut = new InputParser(_gameState, inputs, lines, _analyser);
            
            sut.UpdateGameState(inputs, opponentOrders);

            _gameState.MyCoordinates.Should().BeEquivalentTo(new Cell(4, 5));
            _gameState.MyLife.Should().Be(3);
            _gameState.OpponentLife.Should().Be(2);
            _gameState.OpponentOrders.Should().Be("Wibble");
        }
    }
}
