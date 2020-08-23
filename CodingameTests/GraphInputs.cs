using System;
using System.Collections.Generic;

namespace CodingameTests
{
    class GraphInputs
    {
        public int NoOfNodes { get; set; }
        public List<(int, int)> Links { get; set; }
        public List<int> GatewayIndexes { get; set; }
        public int VirusPosition { get; set; }

        public GraphInputs()
        {
            Links = new List<(int, int)>();
            GatewayIndexes = new List<int>();
        }

        public void GenerateGraphInputs(Queue<string> args)
        {
            Func<string> readLine = () => args.Dequeue();

            var initialInputs = readLine().Split(' ');
            NoOfNodes = int.Parse(initialInputs[0]);

            var noOfLinks = int.Parse(initialInputs[1]);
            for (int i = 0; i < noOfLinks; i++)
            {
                var link = readLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                Links.Add((node1, node2));
            }

            var noOfGateways = int.Parse(initialInputs[2]);
            for (int i = 0; i < noOfGateways; i++)
            {
                var gatewayIndex = int.Parse(readLine());
                GatewayIndexes.Add(gatewayIndex);
            }

            VirusPosition = int.Parse(readLine());
        }
    }
}
