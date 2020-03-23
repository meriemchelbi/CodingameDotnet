using Codingame.Model;
using System.Collections.Generic;

namespace Codingame
{
    internal class PlayerActions
    {
        internal List<string> Actions { get; set; }
        private GameState _gameState;

        internal PlayerActions(GameState gameState)
        {
            _gameState = gameState;
        }

        internal void SetStartingPosition()
        {
            Actions = new List<string> { "3 5" };
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
