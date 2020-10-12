﻿using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    public class Graph
    {
        public List<Link> Links { get; set; }
        public List<Node> Nodes { get; set; }
        public Virus Virus { get; set; }

        public Graph()
        {
            Links = new List<Link>();
            Nodes = new List<Node>();
        }

        public void BuildGraph(int noOfNodes, List<(int, int)> links, List<int> gatewayIndexes)
        {
            AddNodes(noOfNodes);
            AddLinks(links);

            for (int i = 0; i < gatewayIndexes.Count; i++)
            {
                var gatewayIndex = gatewayIndexes[i];
                Nodes[gatewayIndex].IsGateway = true;
            }

            Virus = new Virus();
        }

        public void AddLink(int firstNodeId, int secondNodeId)
        {
            var nodeA = GetNode(firstNodeId);
            var nodeB = GetNode(secondNodeId);

            Links.Add(new Link(nodeA, nodeB));

            if (!nodeA.Neighbours.Contains(nodeB))
                nodeA.Neighbours.Add(nodeB);

            if (!nodeB.Neighbours.Contains(nodeA))
                nodeB.Neighbours.Add(nodeA);
        }

        public Node GetNode(int nodeId)
        {
            return Nodes.FirstOrDefault(n => n.Id == nodeId);
        }

        public Link GetLink(int origin, int destination)
        {
            return Links.FirstOrDefault(l => l.Origin.Id == origin 
                                          && l.Destination.Id == destination);
        }

        public IEnumerable<Node> GetGateways()
        {
            return Nodes.Where(n => n.IsGateway);
        }

        public void SeverLink(List<Node> path)
        {
            var linkOrigin = path[0].Id;
            var linkDestination = path[1].Id;
            Links.Remove(GetLink(linkOrigin, linkDestination));
        }

        private void AddLinks(List<(int, int)> links)
        {
            for (int i = 0; i < links.Count; i++)
            {
                var node1 = links[i].Item1;
                var node2 = links[i].Item2;
                AddLink(node1, node2);
            }
        }

        private void AddNodes(int noOfNodes)
        {
            // Node ID must correspond to the node's index in the Nodes collection
            for (int i = 0; i < noOfNodes; i++)
                Nodes.Add(new Node(i));
        }
    }
}
