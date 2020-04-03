using System.Collections.Generic;

namespace Codingame
{
    class InputParser
    {
        private GameState _gameState;
        private string[] _inputs;
        private readonly List<string> _lines;
        private FrequencyAnalyser _frequencyAnalyser;

        public InputParser(GameState gameState, string[] inputs, List<string> lines, FrequencyAnalyser frequencyAnalyser)
        {
            _gameState = gameState;
            _inputs = inputs;
            _lines = lines;
            _frequencyAnalyser = frequencyAnalyser;
        }

        public void LoadGameState()
        {
            var height = int.Parse(_inputs[1]);
            var width = int.Parse(_inputs[0]);

            _gameState.MapHeight = height;
            _gameState.MapWidth = width;
            _gameState.PlayerStartsFirst = int.Parse(_inputs[2]) == 0;

            _gameState.CellMap = new Cell[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    _gameState.CellMap[i, j] = new Cell(_lines[i][j].ToString(), i, j);
                    _gameState.CellMap[j, i] = new Cell(_lines[j][i].ToString(), j, i);
                }
            }
        }

        public void UpdateGameState(string[] inputs, string opponentOrders)
        {
            _gameState.MyCoordinates = _gameState.CellMap[int.Parse(inputs[1]), int.Parse(inputs[0])];
            _gameState.MyLife = int.Parse(inputs[2]);
            _gameState.OpponentLife = int.Parse(inputs[3]);
            _gameState.OpponentOrders = opponentOrders;

            //int torpedoCooldown = int.Parse(inputs[4]);
            //int sonarCooldown = int.Parse(inputs[5]);
            //int silenceCooldown = int.Parse(inputs[6]);
            //int mineCooldown = int.Parse(inputs[7]);

            // using frequency analyser work out enemy position
        }
    }
}
