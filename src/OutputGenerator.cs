using System;
using System.Linq;
using System.Text;

namespace Codingame.Model
{
    internal class OutputGenerator
    {
        private PlayerActions _playerActions;
        private GameState _gameState;
        // ideally would like these fields private as well as testable- any way around this?
        internal string GameStateOutput;
        internal string GameOutput;
        

        internal OutputGenerator(GameState gameState, PlayerActions playerActions)
        {
            _gameState = gameState;
            _playerActions = playerActions;
        }

        internal void OutputActions()
        {
            ConstructGameOutput();
            Console.WriteLine(GameOutput);
        }

        internal void DisplayGameState()
        {
            ConstructGameState();
            Console.Error.WriteLine(GameStateOutput);
        }

        private void ConstructGameState()
        {
            GameStateOutput = "wibble";
        }
        
        private void ConstructGameOutput()
        {
            var stringBuilder = new StringBuilder();
            var numberOfActions = _playerActions.Actions.Count;
            
            if ( numberOfActions > 1)
            {
                for (int i = 0; i < numberOfActions - 1; i++)
                {
                    stringBuilder.Append(_playerActions.Actions[i] + " | ");
                }
            }
            
            stringBuilder.Append(_playerActions.Actions[numberOfActions - 1]);
            GameOutput = stringBuilder.ToString();
            _playerActions.Actions.Clear();
        }
    }
}
