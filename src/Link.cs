using System;
using System.Collections.Generic;
using System.Text;

namespace Codingame
{
    public class Link
    {
        public Node Origin { get; }
        public Node Destination { get; }
        public bool IsSevered { get; set; }

        public Link(Node origin, Node destination)
        {
            Origin = origin;
            Destination = destination;
        }
    }
}
