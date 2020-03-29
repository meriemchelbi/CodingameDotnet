using System;
using System.Collections.Generic;
using System.Linq;

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
            var corners = GetMapCorners();

            var selected = corners.Where(c => c.Value == ".").FirstOrDefault() 
                ?? GetFirstFreeCell();

            var action = $"{selected.Coordinates.Item1} {selected.Coordinates.Item2}";
            Actions.Add(action);

        }

        internal void Act()
        {
            Move();
        }

        private List<Cell> GetMapCorners()
        {
            var lastCol = _gameState.MapWidth - 1;
            var lastRow = _gameState.MapHeight - 1;

            return new List<Cell>
            {
                _gameState.CellMap[0, 0],
                _gameState.CellMap[0, lastCol],
                _gameState.CellMap[lastRow, 0],
                _gameState.CellMap[lastRow, lastCol]
            };
        }

        private Cell GetFirstFreeCell()
        {
            var width = _gameState.CellMap.GetLength(0);
            var height = _gameState.CellMap.GetLength(1);
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (_gameState.CellMap[i, j].Value == ".")
                        return _gameState.CellMap[i, j];
                }
            }

            return null;
        }

        private void Move()
        {
            Actions.Add("MOVE E");
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
