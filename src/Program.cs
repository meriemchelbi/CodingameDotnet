using System;
using System.Collections.Generic;

namespace Codingame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputs;

            inputs = Console.ReadLine().Split(' ');

            var noOfNodes = int.Parse(inputs[0]);
            Console.Error.WriteLine($"No of nodes: {noOfNodes}");

            var noOfLinks = int.Parse(inputs[1]);
            Console.Error.WriteLine($"No of Links: {noOfLinks}");

            var noOfGateways = int.Parse(inputs[2]);
            Console.Error.WriteLine($"No of gateways: {noOfGateways}");

            var links = new List<(int, int)>();
            for (int i = 0; i < noOfLinks; i++)
            {
                var link = Console.ReadLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                links.Add((node1, node2));
                Console.Error.WriteLine($"Nodes {node1} and node {node2} are linked");
            }

            var gatewayIndexes = new List<int>();
            for (int i = 0; i < noOfGateways; i++)
            {
                var gatewayIndex = int.Parse(Console.ReadLine());
                gatewayIndexes.Add(gatewayIndex);
                Console.Error.WriteLine($"Gateway index: {gatewayIndex}");
            }

            KillTheVirus(noOfNodes, links, gatewayIndexes);

            static string KillTheVirus(int noOfNodes, List<(int, int)> links, List<int> gatewayIndexes)
            {
                var skynet = new Graph();
                skynet.BuildGraph(noOfNodes, links, gatewayIndexes);
                var game = new Game(skynet);

                while (true)
                {
                    var currentPosition = int.Parse(Console.ReadLine());
                    Console.Error.WriteLine($"Agent's current position is: {currentPosition}");

                    skynet.Virus.CurrentPosition = skynet.Nodes[currentPosition];

                    var nextMove = game.FindTargetLink();

                    Console.WriteLine(nextMove);
                }
            }
        }
    }
}
