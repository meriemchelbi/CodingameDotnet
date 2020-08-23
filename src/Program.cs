using System;

namespace Codingame
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO introduce GetInput method that splits the input into component parts.
            // Change BuildGraph to take these inputs, and KillTheVirus to take the graph as single argument
            // That way, you can bypass GetInput in your tests and just new up a collection
            KillTheVirus(args);

            static string KillTheVirus(string[] args)
            {
                var skynet = new Graph();
                skynet.BuildGraph(args);

                while (true)
                {
                    var virusPosition = skynet.Virus.GetCurrentPosition();
                    skynet.Virus.CurrentPosition = skynet.Nodes[virusPosition];
                    Console.WriteLine("2 3");
                }
            }
        }
    }
}
