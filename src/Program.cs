using Codingame.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CodingameTests")]
namespace Codingame
{
    class Player
    {
        static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            var height = int.Parse(inputs[1]);
            var map = new List<string>();

            for (int i = 0; i < height; i++)
            {
                var line = Console.ReadLine();
                map.Add(line);
            }

            var gameState = new GameState();
            var frequencyAnalyser = new FrequencyAnalyser(gameState);
            var playerActions = new PlayerActions(gameState);
            var inputParser = new InputParser(gameState, inputs, map, frequencyAnalyser);
            var outputGenerator = new OutputGenerator(gameState, playerActions);

            inputParser.LoadGameState();
            playerActions.SetStartingPosition();
            outputGenerator.OutputActions();

            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                var sonarResult = Console.ReadLine();
                var opponentOrders = Console.ReadLine();

                inputParser.UpdateGameState(inputs, opponentOrders);
                outputGenerator.DisplayGameState();
                playerActions.Act();
                outputGenerator.OutputActions();
            }
        }
    }
}
