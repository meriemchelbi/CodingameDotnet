﻿namespace Codingame
{
    internal class Cell
    {
        internal (int, int) Coordinates { get; set; }
        internal string Value { get; set; }
        internal bool Visited { get; set; }

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
            return cell1.Coordinates == cell2.Coordinates;
        }
    }

}
