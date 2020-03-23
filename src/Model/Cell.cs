using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    internal class Cell
    {
        public (int, int) Coordinates { get; set; }
        public CellValues Value { get; set; }
        public bool Visited { get; set; }
    }

    public enum CellValues
    {
        Island,
        //Enemy,
        Empty
    }
}
