using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    class InputParser
    {
        public InputParser()
        {
            // inject game state
            // Inject inputs (string[])
            // Inject List<string> lines
            // Inject FrequencyAnalyser
        }

        public void LoadGameState()
        {
        }

        public void UpdateGameState(string[] inputs)
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
        }
    }
}
