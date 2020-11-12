using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    public class Recipe
    {
        public int Id { get; set; }
        public ActionType Type { get; set; }
        public int[] Ingredients { get; set; }
        public int Price { get; set; }
    }
}
