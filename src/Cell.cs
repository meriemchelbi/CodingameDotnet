using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    internal class Cell
    {
        // Coordinates stored in index format (i.e. [row/y , col/x] as opposed to algebraic (col/x, row/y)
        internal int RowY { get; set; }
        internal int ColX { get; set; }
        internal string Value { get; set; }
        internal bool Visited { get; set; }
        //internal List<Cell> FreeNeighbours { get; set; }
        //internal int Score 
        //{
        //    get
        //    {
        //        if (_score == 0)
        //            ComputeNavigationScore();
        //        return _score;
        //    }
        //}
        private int _score;

        internal Cell(string value, int rowY, int columnX)
        {
            Value = value;
            RowY = rowY;
            ColX = columnX;
            _score = 0;
        }

        public override string ToString()
        {
            return $"Column/X {ColX}, Row/Y: {RowY}, Visited: {Visited}, Value: {Value}, Is free? {IsFree()}";
        }

        internal bool Equals(Cell cell1, Cell cell2)
        {
            return (cell1.RowY == cell2.RowY)
                && (cell1.ColX == cell2.ColX);
        }

        internal bool IsFree()
        {
            return Value == "." && !Visited;
        }

        //private void ComputeNavigationScore()
        //{
        //    foreach (var neighbour in FreeNeighbours)
        //    {
        //        _score += neighbour.Score;
        //    }
        //    _score += FreeNeighbours.Count;
        //}
    }

}
