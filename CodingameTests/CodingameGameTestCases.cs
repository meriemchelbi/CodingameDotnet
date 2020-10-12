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

            result.Should().Be(expectedOutput);
        }

        [Fact]
        public void TripleStar_38Nodes_Round1()
        {
            var standinput = new Queue<string>(new[]
            {
                "38 79 3", // no of nodes, no of links, no of gateways
                "28 36",
                "0 2",
                "3 34",
                "29 21",
                "37 35",
                "28 32",
                "0 10",
                "37 2",
                "4 5",
                "13 14",
                "34 35",
                "27 19",
                "28 34",
                "30 31",
                "18 26",
                "0 9",
                "7 8",
                "18 24",
                "18 23",
                "0 5",
                "16 17",
                "29 30",
                "10 11",
                "0 12",
                "15 16",
                "0 11",
                "0 17",
                "18 22",
                "23 24",
                "0 7",
                "35 23",
                "22 23",
                "1 2",
                "0 13",
                "18 27",
                "25 26",
                "32 33",
                "28 31",
                "24 25",
                "28 35",
                "21 22",
                "4 33",
                "28 29",
                "36 22",
                "18 25",
                "37 23",
                "18 21",
                "5 6",
                "19 20",
                "0 14",
                "35 36",
                "9 10",
                "0 6",
                "20 21",
                "0 3",
                "33 34",
                "14 15",
                "28 33",
                "11 12",
                "12 13",
                "17 1",
                "18 19",
                "36 29",
                "0 4",
                "0 15",
                "0 1",
                "18 20",
                "2 3",
                "0 16",
                "8 9",
                "0 8",
                "26 27",
                "28 30",
                "3 4",
                "31 32",
                "6 7",
                "37 1",
                "37 24",
                "35 2",
                "0",
                "18",
                "28",
                "37"
            });

            var inputs = new GraphInputs();
            inputs.GenerateGraphInputs(standinput);

            var skynet = new Graph();
            skynet.BuildGraph(inputs.NoOfNodes, inputs.Links, inputs.GatewayIndexes);
            skynet.Virus.CurrentPosition = skynet.Nodes[inputs.VirusPosition];

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().BeOneOf("2 0");
        }
        
        [Fact]
        public void TripleStar_38Nodes_SeveredLink()
        {
            var standinput = new Queue<string>(new[]
            {
                "38 79 3", // no of nodes, no of links, no of gateways
                "28 36",
                "0 2",
                "3 34",
                "29 21",
                "37 35",
                "28 32",
                "0 10",
                "37 2",
                "4 5",
                "13 14",
                "34 35",
                "27 19",
                "28 34",
                "30 31",
                "18 26",
                "0 9",
                "7 8",
                "18 24",
                "18 23",
                "0 5",
                "16 17",
                "29 30",
                "10 11",
                "0 12",
                "15 16",
                "0 11",
                "0 17",
                "18 22",
                "23 24",
                "0 7",
                "35 23",
                "22 23",
                "1 2",
                "0 13",
                "18 27",
                "25 26",
                "32 33",
                "28 31",
                "24 25",
                "28 35",
                "21 22",
                "4 33",
                "28 29",
                "36 22",
                "18 25",
                "37 23",
                "18 21",
                "5 6",
                "19 20",
                "0 14",
                "35 36",
                "9 10",
                "0 6",
                "20 21",
                "0 3",
                "33 34",
                "14 15",
                "28 33",
                "11 12",
                "12 13",
                "17 1",
                "18 19",
                "36 29",
                "0 4",
                "0 15",
                "0 1",
                "18 20",
                "2 3",
                "0 16",
                "8 9",
                "0 8",
                "26 27",
                "28 30",
                "3 4",
                "31 32",
                "6 7",
                "37 1",
                "37 24",
                "35 2",
                "0",
                "18",
                "28",
                "35"
            });

            var inputs = new GraphInputs();
            inputs.GenerateGraphInputs(standinput);

            var skynet = new Graph();
            skynet.BuildGraph(inputs.NoOfNodes, inputs.Links, inputs.GatewayIndexes);
            skynet.Virus.CurrentPosition = skynet.Nodes[inputs.VirusPosition];
            skynet.GetLink(0, 2).IsSevered = true;

            var game = new Game(skynet);

            var result = game.FindTargetLink();

            result.Should().BeOneOf("35 28");
        }
    }
}
