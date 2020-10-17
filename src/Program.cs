using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
namespace Codingame
{
    public class Solution
    {
        static void Main(string[] args)
        {
            string MESSAGE = Console.ReadLine();

            var result = ChuckNorrisEncoder.Encode(MESSAGE);

            Console.WriteLine(result);
        }
    }
}