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
            Actions = new List<string>();
        }

        internal void SetStartingPosition()
        {
            Actions.Add("3 7");
        }

        internal void Act()
        {
            Move();
        }

        private void Move()
        {
            Actions.Add("MOVE N");
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
