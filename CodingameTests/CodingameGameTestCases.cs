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
        
        [Theory]
        [InlineData("11", "6 0")]
        [InlineData("5", "5 0")]
        [InlineData("4", "4 0")]
        [InlineData("3", "3 0")]
        [InlineData("2", "2 0")]
        [InlineData("10", "10 0")]
        [InlineData("9", "9 0")]
        [InlineData("8", "8 0")]
        [InlineData("7", "7 0")]
        public void Star_TwelveNodes(string agentPosition, string expectedOutput)
        {
            var standinput = new Queue<string>(new[]
            {
                "12 23 1", // no of nodes, no of links, no of gateways
                "11 6",
                "0 9", 
                "1 2", 
                "0 1", 
                "10 1",
                "11 5",
                "2 3",
                "4 5",
                "8 9",
                "6 7",
                "7 8",
                "0 6",
                "3 4",
                "0 2",
                "11 7",
                "0 8",
                "0 4",
                "9 10",
                "0 5",
                "0 7",
                "0 3",
                "0 10",
                "5 6",
                "0", // index of gateway node (each new gateway node is provided as a separate input/line
                agentPosition // position of agent
           });

            var inputs = new GraphInputs();
            inputs.GenerateGraphInputs(standinput);

            var skynet = new Graph();
            skynet.BuildGraph(inputs.NoOfNodes, inputs.Links, inputs.GatewayIndexes);
            skynet.Virus.CurrentPosition = skynet.Nodes[inputs.VirusPosition];

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().ContainAny(expectedOutput);
        }
    }
}
