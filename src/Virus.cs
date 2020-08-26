using System;

namespace Codingame
{
    public class Virus
    {
        public Node CurrentPosition { get; set; }

        public int GetCurrentPosition()
        {
            var currentPosition = int.Parse(Console.ReadLine());

            Console.Error.WriteLine($"Agent's current position is: {currentPosition}");
            return currentPosition;
        }
    }
}
