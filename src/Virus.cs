using System;

namespace Codingame
{
    public class Virus
    {
        public Node CurrentPosition { get; set; }

        public int GetCurrentPosition()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
