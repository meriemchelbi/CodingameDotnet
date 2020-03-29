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

            _sut.Actions.Should().Contain("2 0");
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

            _sut.Actions.Should().Contain("0 1");
        }

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
