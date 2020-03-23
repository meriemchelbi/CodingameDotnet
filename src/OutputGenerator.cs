using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame.Model
{
    internal class OutputGenerator
    {
        private PlayerActions _playerActions;
        private GameState _gameState;
        private string _gameStateOutput;
        private string _gameOutput;
        

        internal OutputGenerator(GameState gameState, PlayerActions playerActions)
        {
            _gameState = gameState;
            _playerActions = playerActions;
        }

        internal void OutputActions()
        {
            // using GameOutput & Console.Writeline
        }

        internal void DisplayGameState()
        {
            // using gameStateOutput & Console.Error.WriteLine("Debug messages...")
        }

        private string ConstructGameState()
        {
            // from Map
            return string.Empty;
        }
        
        private string ConstructGameOutput()
        {
            // using PlayerActions (make sure you clear them when done)
            return string.Empty;
        }
    }
}
