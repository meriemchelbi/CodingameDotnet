using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    class Sector
    {
        internal string Name { get; }
        internal List<Cell> Cells { get; }

        internal Sector(string name)
        {
            Name = name;
        }
    }
}
