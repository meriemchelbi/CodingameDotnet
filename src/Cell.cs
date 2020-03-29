using System;
using System.Collections.Generic;

namespace Codingame
{
    internal class Cell
    {
        internal (int, int) Coordinates { get; set; }
        internal string Value { get; set; }
        internal bool Visited { get; set; }
        internal int Score { get; set; }

        internal Cell(int x, int y)
        {
            Coordinates = (x, y);
        }
        
        internal Cell(string value, int x, int y)
        {
            Value = value;
            Coordinates = (x, y);
        }

        internal bool Equals(Cell cell1, Cell cell2)
        {
            return (cell1.Coordinates.Item1 == cell2.Coordinates.Item1)
                && (cell1.Coordinates.Item2 == cell2.Coordinates.Item2);
        }

        public override string ToString()
        {
            return $"({Coordinates.Item1}, {Coordinates.Item2}, Visited: {Visited}, Value: {Value}, Is free? {IsFree()} )";
        }

        internal bool IsFree()
        {
            return Value == "." && !Visited;
        }
    }

}
