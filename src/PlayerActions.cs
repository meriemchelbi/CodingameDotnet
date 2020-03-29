using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    internal class PlayerActions
    {
        public const string North = "N";
        public const string South = "S";
        public const string East = "E";
        public const string West = "W";
        internal List<string> Actions { get; set; }
        internal string PreviousDirection { get; set; }
        private readonly List<Cell> _freeNeighbours;
        private GameState _gameState;

        internal PlayerActions(GameState gameState)
        {
            _gameState = gameState;
            Actions = new List<string>();
            _freeNeighbours = new List<Cell>();
        }

        internal void SetStartingPosition()
        {
            var corners = GetMapCorners();

            var selected = corners.Where(c => c.IsFree()).FirstOrDefault() 
                ?? GetFirstFreeCell();

            selected.Visited = true;

            Actions.Add($"{selected.Coordinates.Item1} {selected.Coordinates.Item2}");
        }

        internal void Act()
        {
            _gameState.MyCoordinates.Visited = true;
            
            FindFreeNeighbours();
            _freeNeighbours.ForEach(c => Console.Error.WriteLine($"free neighbour {c.ToString()}"));

            if (_freeNeighbours.Count > 0)
                Move();
            else Surface();
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
                    var cell = _gameState.CellMap[i, j];
                    if (cell.IsFree())
                        return _gameState.CellMap[i, j];
                }
            }

            return null;
        }

        private void FindFreeNeighbours()
        {
            _freeNeighbours.Clear();

            var x = _gameState.MyCoordinates.Coordinates.Item1;
            var y = _gameState.MyCoordinates.Coordinates.Item2;

            // feels I could simplify this?
            var north = x > 0
                ? _gameState.CellMap[y , x - 1]
                : null;
            if (north != null && north.IsFree()) _freeNeighbours.Add(north);

            var south = x < (_gameState.MapHeight - 1)
                ? _gameState.CellMap[y, x + 1]
                : null;
            if (south != null && south.IsFree()) _freeNeighbours.Add(south);

            var east = y < (_gameState.MapWidth - 1)
                ? _gameState.CellMap[y + 1, x]
                : null;
            if (east != null && east.IsFree()) _freeNeighbours.Add(east);

            var west = y > 0
                ? _gameState.CellMap[y - 1, x]
                : null;
            if (west != null && west.IsFree()) _freeNeighbours.Add(west);
        }

        private void Move()
        {
            Console.Error.WriteLine($"previous direction: {PreviousDirection}");
            var nextCellInPath = PreviousDirection != null ? FindNextCell(PreviousDirection) : null;

            // if I can move in current path, do so
            if (PreviousDirection != null && _freeNeighbours.Contains(nextCellInPath))
            {
                Console.Error.WriteLine($"next cell in path: {nextCellInPath.ToString()}");
                Actions.Add($"MOVE {PreviousDirection}");
            }

            // if only one free neighbour or can't move in current path or haven't moved before, move to first free neighbour
            else
            {
                Console.Error.WriteLine($"first free neighbour: {_freeNeighbours[0].ToString()}");
                PreviousDirection = GetRelativeDirection(_freeNeighbours[0]);
                Actions.Add($"MOVE {PreviousDirection}");
            }
        }

        // handle cells not on the map
        private Cell FindNextCell(string direction)
        {
            var myX = _gameState.MyCoordinates.Coordinates.Item1;
            var myY = _gameState.MyCoordinates.Coordinates.Item2;
            var height = _gameState.MapHeight;
            var width = _gameState.MapWidth;

            if (direction.Equals("N") && myY > 0)
            {
                return _gameState.CellMap[myX, myY - 1];
            }
            
            if (direction.Equals("S") && myY < height - 1)
            {
                return _gameState.CellMap[myX, myY + 1];
            }
            
            if (direction.Equals("E") && myX < width - 1)
            {
                return _gameState.CellMap[myX + 1, myY];
            }
            
            if (direction.Equals("W") && myX > 0)
            {
                return _gameState.CellMap[myX - 1, myY];
            }

            else
                return null;
        }

        private string GetRelativeDirection(Cell neighbour)
        {
            return neighbour.Coordinates.Item1 < _gameState.MyCoordinates.Coordinates.Item1
                ? "N"
                : neighbour.Coordinates.Item1 > _gameState.MyCoordinates.Coordinates.Item1
                    ? "S"
                    : neighbour.Coordinates.Item2 > _gameState.MyCoordinates.Coordinates.Item2
                        ? "E"
                        : neighbour.Coordinates.Item2 < _gameState.MyCoordinates.Coordinates.Item2
                            ? "W"
                            : null;
        }

        private void Surface()
        {
            Actions.Add("SURFACE");

            foreach (var cell in _gameState.CellMap)
            {
                cell.Visited = false;
            }
        }

        private void Torpedo()
        {
            // do the thing & add to Actions
        }
    }
}