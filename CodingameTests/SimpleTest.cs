using Codingame;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodingameTests
{
    public class SimpleTest
    {
        [Fact]
        public void ThreeNodes_AgentPos1_Returns_1_2()
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

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().Be("1 2");
        }
    }
}
