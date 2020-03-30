using System;
using System.Linq;
using System.Text;

namespace Codingame
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
            ConstructGameStateOutput();
            Console.Error.WriteLine(GameStateOutput);
        }

        private void ConstructGameStateOutput()
        {
            var printedMap = PrintCellMap();

            GameStateOutput = 

$@"Game state:
Map Height: {_gameState.MapHeight}
Map Width: {_gameState.MapWidth}
Cell Map:
{printedMap}
My position: {_gameState.Me.ToString()}
My life: {_gameState.MyLife}
Opponent life: {_gameState.OpponentLife}
Opponent orders: {_gameState.OpponentOrders}
I start first? {_gameState.PlayerStartsFirst}";
        }

        private string PrintCellMap()
        {
            var sb = new StringBuilder();
            var rowLength = _gameState.CellMap.GetLength(0);
            var colLength = _gameState.CellMap.GetLength(1);

            sb.Append("\n");
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    sb.Append(_gameState.CellMap[i, j].Value + " ");
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        private void ConstructGameOutput()
        {
            var stringBuilder = new StringBuilder();
            var numberOfActions = _playerActions.Actions.Count;

            if (numberOfActions > 1)
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
