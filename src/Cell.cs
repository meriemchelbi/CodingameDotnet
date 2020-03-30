using System;
using System.Collections.Generic;

namespace Codingame
{
    internal class Cell
    {
        // Coordinates stored in index format (i.e. [row/y , col/x] as opposed to algebraic (col/x, row/y)
        internal int RowY { get; set; }
        internal int ColX { get; set; }
        internal string Value { get; set; }
        internal bool Visited { get; set; }
        internal int Score { get; set; }

        internal Cell(int rowY, int columnX)
        {
            RowY = rowY;
            ColX = columnX;
        }
        
        internal Cell(string value, int rowY, int columnX)
        {
            Value = value;
            RowY = rowY;
            ColX = columnX;
        }

        internal bool Equals(Cell cell1, Cell cell2)
        {
            return (cell1.RowY == cell2.RowY)
                && (cell1.ColX == cell2.ColX);
        }

        public override string ToString()
        {
            return $"Column/X {ColX}, Row/Y: {RowY}, Visited: {Visited}, Value: {Value}, Is free? {IsFree()}";
        }

        internal bool IsFree()
        {
            return Value == "." && !Visited;
        }
    }

}
