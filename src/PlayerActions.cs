using Codingame.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    internal class PlayerActions
    {
        internal string[] Actions { get; set; }
        private GameState _gameState;

        internal PlayerActions(GameState gameState)
        {
            _gameState = gameState;
        }

        internal void SetStartingPosition()
        {
            // Add to Actions
        }

        internal void Act()
        {
            // Call each method as appropriate
        }

        private void Move()
        {
            // do the thing & add to Actions
        }

        private void Surface()
        {
            // do the thing & add to Actions
        }

        private void Torpedo()
        {
            // do the thing & add to Actions
        }
    }
}
