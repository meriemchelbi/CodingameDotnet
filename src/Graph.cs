using System;
using System.Collections.Generic;

namespace Codingame
{
    public class Graph
    {
        public List<(int, int)> Links { get; set; }
        public List<Node> Nodes { get; set; }
        public Virus Virus { get; set; }

        public Graph()
        {
            Links = new List<(int, int)>();
            Nodes = new List<Node>();
        }

        public void AddLink(int firstNodeId, int secondNodeId)
        {
            var nodeA = Nodes[firstNodeId];
            var nodeB = Nodes[secondNodeId];

            Links.Add((firstNodeId, secondNodeId));

            if (!nodeA.Neighbours.Contains(nodeB))
                nodeA.Neighbours.Add(nodeB);

            if (!nodeB.Neighbours.Contains(nodeA))
                nodeB.Neighbours.Add(nodeA);
        }

        public void AddNodes(int noOfNodes)
        {
            // Node ID must correspond to the node's index in the Nodes collection
            for (int i = 0; i < noOfNodes; i++)
                Nodes.Add(new Node(i));
        }

        // TODO Refactor BuildGraph to take in specific inputs
        public void BuildGraph(int noOfNodes, List<(int, int)> links, List<int> gatewayIndexes)
        {
            AddNodes(noOfNodes);

            for (int i = 0; i < links.Count; i++)
            {
                var node1 = links[i].Item1;
                var node2 = links[i].Item2;
                AddLink(node1, node2);
            }

            for (int i = 0; i < gatewayIndexes.Count; i++)
            {
                var gatewayIndex = gatewayIndexes[i];
                Nodes[gatewayIndex].IsGateway = true;
            }

            Virus = new Virus();
        }
    }
}
