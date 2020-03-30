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
        public void SetStartingPosition_NoFreeCorners_SelectsFirstFreeCell()
        {
            _gameState.CellMap = new Cell[,]
            {
                { new Cell("x", 0, 0), new Cell(".", 0, 1), new Cell("x", 0, 2) },
                { new Cell(".", 1, 0), new Cell(".", 1, 1), new Cell(".", 1, 2) },
                { new Cell("x", 2, 0), new Cell(".", 2, 1), new Cell("x", 2, 2) }
            };

            _sut.SetStartingPosition();

            // result should be opposite format to cell index, i.e. coordinates (Row/Y, Col/X)
            _sut.Actions.Should().Contain("1 0");
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

            _sut.Actions.Should().Contain("MOVE N");
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

            _sut.Actions.Should().Contain("MOVE S");
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
            _gameState.Me.Visited.Should().BeTrue();
        }
        
        //[Fact]
        //public void Act_MultipleFreeNeighbours_NoPreviousDirection_MoveToHighestScore()
        //{
        //    // optimisation
        //}

        //[Fact]
        //public void SetStartingPosition_MultipleFreeCorners_SelectsCornerWithHighestScore()
        //{
        //    //optimisation
        //}

        //[Fact]
        //public void SetStartingPosition_FreeCornersLowScores_SelectsFirstFreeCell()
        //{
        //    //optimisation
        //}


    }
}
