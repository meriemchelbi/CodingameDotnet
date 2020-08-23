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

            if (!nodeA.Neighbours.Exists(n => n == nodeB))
                nodeA.Neighbours.Add(nodeB);

            if (!nodeB.Neighbours.Exists(n => n == nodeA))
                nodeB.Neighbours.Add(nodeA);
        }

        public void AddNodes(int noOfNodes)
        {
            // Node ID must correspond to the node's index in the Nodes collection
            for (int i = 0; i < noOfNodes; i++)
                Nodes.Add(new Node(i));
        }

        // TODO Refactor BuildGraph to take in specific inputs
        public void BuildGraph(string[] args)
        {
            string[] inputs;

            inputs = Console.ReadLine().Split(' ');

            var noOfNodes = int.Parse(inputs[0]);
            AddNodes(noOfNodes);
            Console.Error.WriteLine($"No of nodes: {noOfNodes}");

            var noOfLinks = int.Parse(inputs[1]);
            Console.Error.WriteLine($"No of Links: {noOfLinks}");

            var noOfGateways = int.Parse(inputs[2]);
            Console.Error.WriteLine($"No of gateways: {noOfGateways}");

            for (int i = 0; i < noOfLinks; i++)
            {
                var link = Console.ReadLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                AddLink(node1, node2);
                Console.Error.WriteLine($"Nodes {node1} and node {node2} are linked");
            }

            for (int i = 0; i < noOfGateways; i++)
            {
                var gatewayIndex = int.Parse(Console.ReadLine());
                Nodes[gatewayIndex].IsGateway = true;
                Console.Error.WriteLine($"Gateway index: {gatewayIndex}");
            }

            Virus = new Virus();
        }
    }
}
