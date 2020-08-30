using Codingame;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CodingameTests
{
    public class CodingameGameTestCases
    {
        [Fact]
        public void SimpleTest_ThreeNodes_AgentPos1()
        {
            var standinput = new Queue<string>(new[]
            {
                "3 2 1", // no of nodes, no of links, no of gateways
                "1 2", // node 1 is linked to node 2
                "1 0", // node 1 is linked to node 0
                "2", // index of gateway node (each new gateway node is provided as a separate input/line
                "1" // position of agent
           });

            var inputs = new GraphInputs();
            inputs.GenerateGraphInputs(standinput);

            var skynet = new Graph();
            skynet.BuildGraph(inputs.NoOfNodes, inputs.Links, inputs.GatewayIndexes);
            skynet.Virus.CurrentPosition = skynet.Nodes[inputs.VirusPosition];

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().Be("1 2");
        }
        
        [Fact]
        public void SeveralPaths_FourNodes_AgentPos0()
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

            var inputs = new GraphInputs();
            inputs.GenerateGraphInputs(standinput);

            var skynet = new Graph();
            skynet.BuildGraph(inputs.NoOfNodes, inputs.Links, inputs.GatewayIndexes);
            skynet.Virus.CurrentPosition = skynet.Nodes[inputs.VirusPosition];

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().ContainAny("1 3", "2 3");
        }
    }
}
