using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
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

            // New gamestate, input parser, frequency analyser, playeractions, output generator
            // Load GameState (using input parser)
            // Set starting position
            // Output actions

            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                var sonarResult = Console.ReadLine();
                var opponentOrders = Console.ReadLine();

                // input parser- update GameState
                // work out opponent position based on orders (using frequency analyser)
                // Display GameState
                // Act
                // output actions
            }
        }
    }
}
