using Codingame;
using System;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class Skynet1
    {
        [Fact]
        public void CanBuildGraph()
        {
            var standinput = new Queue<string>(new[]
            {
                "4 4 1", // no of nodes, no of links, no of gateways
                "1 3", // node 1 is linked to node 3
                "2 3", // node 2 is linked to node 3
                "0 1", // node 0 is linked to node 1
                "0 2", // node 0 is linked to node 2
                "3", // index of gateway node (each new gateway node is provided as a separate input/line
                "0" // position of agent
           });

            Func<string> readLine = () => standinput.Dequeue();

            var initialInputs = readLine().Split(' ');
            var skynet = new Graph();

            var noOfNodes = int.Parse(initialInputs[0]);
            skynet.AddNodes(noOfNodes);

            var noOfLinks = int.Parse(initialInputs[1]);
            for (int i = 0; i < noOfLinks; i++)
            {
                var link = readLine().Split(' ');
                var node1 = int.Parse(link[0]);
                var node2 = int.Parse(link[1]);
                skynet.AddLink(node1, node2);
            }

            var noOfGateways = int.Parse(initialInputs[2]);
            for (int i = 0; i < noOfGateways; i++)
            {
                var gatewayIndex = int.Parse(readLine());
                skynet.Nodes[gatewayIndex].IsGateway = true;
            }

            var virus = new Virus();
            var virusPosition = int.Parse(readLine());
            virus.CurrentPosition = skynet.Nodes[virusPosition];
        }
    }
}
