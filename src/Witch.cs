using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    public class Witch
    {
        public int[] Inventory { get; set; }
        public int Score { get; set; }

        public Witch()
        {
            Inventory = new int[4];
        }
    }
}
