using Codingame.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
            // first load only
        }

        public void UpdateGameState(string[] inputs, string opponentOrders)
        {
            // edit map
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int myLife = int.Parse(inputs[2]);
            int oppLife = int.Parse(inputs[3]);
            int torpedoCooldown = int.Parse(inputs[4]);
            int sonarCooldown = int.Parse(inputs[5]);
            int silenceCooldown = int.Parse(inputs[6]);
            int mineCooldown = int.Parse(inputs[7]);
            // using frequency analyser work out enemy position
        }
    }
}
