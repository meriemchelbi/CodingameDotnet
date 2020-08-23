using System.Collections.Generic;

namespace Codingame
{
    public class Node
    {
        public int Id { get; set; }
        public List<Node> Neighbours { get; set; }
        public bool IsGateway { get; set; }

        public Node(int id)
        {
            Id = id;
            Neighbours = new List<Node>();
        }
    }
}
