using Codingame;
using CodingameTests;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace DojoTemplateTestProject
{
    public class SkynetTests
    {
        [Fact]
        public void BuildGraph_CanBuildGraph()
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

            skynet.Nodes.Should().HaveCount(4);
            for (int i = 0; i < 3; i++)
            {
                skynet.Nodes[i].Id.Should().Be(i);
            }
            skynet.Nodes[3].IsGateway.Should().BeTrue();
            skynet.Links.Should().HaveCount(4);
            skynet.Links.Should().Contain((1, 3));
            skynet.Links.Should().Contain((2, 3));
            skynet.Links.Should().Contain((0, 1));
            skynet.Links.Should().Contain((0, 2));
            skynet.Virus.Should().NotBeNull();
        }
    }
}
