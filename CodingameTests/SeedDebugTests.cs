using Codingame;
using CodingameTests.Debug;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingameTests
{
    public class SeedDebugTests
    {
        private readonly GameState _gameState;
        private readonly Debugger _debugger;
        public SeedDebugTests()
        {
            _gameState = new GameState();
            _debugger = new Debugger(_gameState);
        }

        [Fact]
        public void DebuggerLoadsInputCorrectly()
        {
            _debugger.LoadDebugGameState();

            _gameState.MyCoordinates.Should().NotBeNull();
            _gameState.CellMap.Should().NotBeNull();
            _gameState.MapHeight.Should().BeGreaterThan(0);
            _gameState.MapWidth.Should().BeGreaterThan(0);
            (_gameState.MapWidth == _gameState.MapHeight).Should().BeTrue();
        }
    }
}
