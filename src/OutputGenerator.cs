using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame.Model
{
    internal class OutputGenerator
    {
        private string _gameOutput { get; set; }
        private string _gameStateOutput { get; set; }

        internal OutputGenerator()
        {
            // inject GameState
            // inject PlayerActions
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
