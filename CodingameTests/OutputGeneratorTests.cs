using Codingame;
using FluentAssertions;
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

//        [Fact] // For visual comparison only.
//        public void ConstructGameStateGeneratesExpectedOutput()
//        {
//            var gameState = new GameState()
//            {
//                MapHeight = 1,
//                MapWidth = 3,
//                CellMap = new Cell[,]
//                {
//                    { new Cell("x", 0, 0),
//                      new Cell(".", 0, 1),
//                      new Cell(".", 0, 2),
//                    },
//                    { new Cell(".", 1, 0),
//                      new Cell("x", 1, 1),
//                      new Cell(".", 1, 2),
//                    }
//                },
//                MyCoordinates = new Cell(0, 2),
//                MyLife = 13,
//                OpponentLife = 7,
//                OpponentOrders = "MOVE N",
//                PlayerStartsFirst = true
//            };
//            var playerActions = new PlayerActions(gameState);
//            var sut = new OutputGenerator(gameState, playerActions);
//            var expectedOutput =
//@$"Game state:
//Map Height: 1
//Map Width: 3
//Cell Map:

//x . . 
//. x . 

//My position: (0, 2)
//My life: 13
//Opponent life: 7
//Opponent orders: MOVE N
//I start first? True";

//            sut.DisplayGameState();

//            sut.GameStateOutput.Should().Be(expectedOutput);
//        }
    }
}
