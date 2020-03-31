using Codingame;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingameTests
{
    public class PlayerActionsTests
    {
        private readonly GameState _gameState;
        private readonly PlayerActions _sut;

        public PlayerActionsTests()
        {
            _gameState = new GameState
            {
                MapHeight = 3,
                MapWidth = 3
            };
            _sut = new PlayerActions(_gameState);
        }

        [Fact]
        public void Act_SetsVisitedFlag_WhenSubMovesOffCell()
        {
            _gameState.MapHeight = 3;
            _gameState.MapWidth = 1;
            _gameState.CellMap = new Cell[,]
            {
                { new Cell("x", 0, 0) },
                { new Cell(".", 1, 0) },
                { new Cell(".", 2, 0) }
            };
            _gameState.Me = _gameState.CellMap[1, 0];

            _sut.Act();

            _gameState.CellMap[0, 0].Visited.Should().BeFalse();
            _gameState.CellMap[1, 0].Visited.Should().BeTrue();
            _gameState.CellMap[2, 0].Visited.Should().BeFalse();
        }

        [Fact]
        public void SetStartingPosition_OneFreeCorner_SelectsFreeCorner()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell("x", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell(".", 1, 0), new Cell(".", 1, 1), new Cell(".", 1, 2) },
                { new Cell(".", 2, 0), new Cell(".", 2, 1), new Cell("x", 2, 2) }
            };

            _sut.SetStartingPosition();

            // result should be opposite format to cell index, i.e. coordinates (Row/Y, Col/X)
            _sut.Actions.Should().Contain("0 2");
        }

        [Fact]
        public void SetStartingPosition_MultipleFreeCorners_SelectsFirstCornerWithHighestScore()
        {
            _gameState.MapHeight = 5;
            _gameState.MapWidth = 4;

            var corner1 = new Cell(".", 0, 0);
            var corner2 = new Cell(".", 0, 3);
            var corner3 = new Cell(".", 4, 0);
            var corner4 = new Cell(".", 4, 3);

            _gameState.CellMap = new Cell[,]
            {
                { corner1, new Cell(".", 0, 1), new Cell("X", 0, 2), corner2 },
                { new Cell("x", 1, 0), new Cell("x", 1, 1), new Cell("x", 1, 2), new Cell("x", 1, 3) },
                { new Cell("x", 2, 0), new Cell("x", 2, 1), new Cell(".", 2, 2), new Cell(".", 2, 3) },
                { new Cell(".", 3, 0), new Cell(".", 3, 1), new Cell(".", 3, 2), new Cell(".", 3, 3) },
                { corner3, new Cell("x", 4, 1), new Cell("x", 4, 2), corner4 }
            };

            _sut.SetStartingPosition();
            var expectedResults = new List<string> { "0 4", "3 4" };

            corner1.Score.Should().Be(1);
            corner2.Score.Should().Be(0);
            (corner3.Score > corner2.Score).Should().BeTrue();
            (corner4.Score > corner2.Score).Should().BeTrue();
            _sut.Actions.Should().HaveCount(1);
            _sut.Actions.Should().BeSubsetOf(expectedResults);
        }

        [Fact]
        public void SetStartingPosition_NoFreeCorners_SelectsFirstFreeCellWithHighestScore()
        {
            _gameState.MapHeight = 6;
            _gameState.MapWidth = 4;
            _gameState.CellMap = new Cell[,]
            {
                { new Cell("x", 0, 0), new Cell(".", 0, 1), new Cell(".", 0, 2), new Cell("x", 0, 3) },
                { new Cell("x", 1, 0), new Cell("x", 1, 1), new Cell("x", 1, 2), new Cell("x", 1, 3) },
                { new Cell(".", 2, 0), new Cell("x", 2, 1), new Cell(".", 2, 2), new Cell(".", 2, 3) },
                { new Cell(".", 3, 0), new Cell("x", 3, 1), new Cell(".", 3, 2), new Cell(".", 3, 3) },
                { new Cell(".", 4, 0), new Cell("x", 4, 1), new Cell("x", 4, 2), new Cell("x", 4, 3) },
                { new Cell("x", 5, 0), new Cell("x", 5, 1), new Cell("x", 5, 2), new Cell("x", 5, 3) }
            };

            _sut.SetStartingPosition();
            var expectedResults = new List<string> { "2 2", "2 3", "3 2", "3 3" };

            _sut.Actions.Should().HaveCount(1);
            _sut.Actions.Should().BeSubsetOf(expectedResults);
        }

        [Fact]
        public void Act_SurfaceWhenNoFreeNeighbours()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell("x", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell(".", 1, 0), new Cell("x", 1, 1), new Cell(".", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell("x", 2, 2) }
            };
            _gameState.Me = _gameState.CellMap[1, 0];
            _gameState.CellMap[0, 1].Visited = true;

            _sut.Act();

            _gameState.CellMap[0, 1].Visited.Should().BeFalse();
            _sut.Actions.Should().Contain("SURFACE");
        }

        [Fact]
        public void Act_OneFreeNeighbour_MoveToFreeNeighbour()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell(".", 0, 0), new Cell("x", 0, 1), new Cell("x", 0, 2) },
                { new Cell("x", 1, 0), new Cell(".", 1, 1), new Cell("x", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell("x", 2, 2) }
            };
            _gameState.Me = _gameState.CellMap[2, 1];
            _sut.PreviousDirection = "S";

            _sut.Act();

            _sut.Actions.Should().Contain("MOVE N TORPEDO");
            _gameState.Me.Visited.Should().BeTrue();
        }

        [Fact]
        public void Act_MultipleFreeNeighbours_PreviousDirection_MoveSameDirection()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell(".", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell("x", 1, 0), new Cell(".", 1, 1), new Cell("x", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell(".", 2, 2) }
            };
            _gameState.Me = _gameState.CellMap[1, 1];
            _sut.PreviousDirection = "S";

            _sut.Act();

            _sut.Actions.Should().Contain("MOVE S TORPEDO");
            _gameState.Me.Visited.Should().BeTrue();
        }

        [Fact]
        public void Act_MultipleFreeNeighbours_NoPreviousDirection_MoveToFirstFreeNeighbour()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell(".", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell("x", 1, 0), new Cell(".", 1, 1), new Cell(".", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell(".", 2, 2) }
            };
            _gameState.Me = _gameState.CellMap[1, 1];
            _sut.PreviousDirection = null;

            _sut.Act();

            _sut.Actions.Should().NotBeEmpty();
            _sut.Actions[0].Should().StartWith("MOVE");
            _sut.Actions[0].Should().EndWith("TORPEDO");
            _gameState.Me.Visited.Should().BeTrue();
        }

        //[Fact]
        //public void Act_MultipleFreeNeighbours_NoPreviousDirection_MoveToHighestScore()
        //{
        //    // optimisation
        //}

        //[Fact]
        //public void SetStartingPosition_FreeCornersLowScores_SelectsFirstFreeCell()
        //{
        //    //optimisation
        //}


    }
}
