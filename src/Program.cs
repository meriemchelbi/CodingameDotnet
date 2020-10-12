using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            var letters = new string[height];

            for (int i = 0; i < height; i++)
            {
                letters[i] = Console.ReadLine();
            }

            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
            var asciiAlphabet = new Dictionary<char, string[]>();

            var position = 0;

            for (int i = 0; i < 27; i++)
            {
                var letter = new string[height];

                for (int row = 0; row < height; row++)
                {
                    letter[row] = letters[row].Substring(position, length);
                    Console.Error.WriteLine($"{letter[row]}");
                }

                position += length;
                asciiAlphabet.Add(alphabet[i], letter);
            }

            var normalisedLetters = input.ToUpperInvariant();
            var output = new string[height];

            foreach (var letter in normalisedLetters)
            {
                string[] asciiLetter;

                var inAlphabet = asciiAlphabet.TryGetValue(letter, out asciiLetter);

                if (!inAlphabet)
                {
                    asciiLetter = asciiAlphabet['?'];
                }

                for (int i = 0; i < height; i++)
                {
                    var letterLine = output[i];
                    output[i] = letterLine + asciiLetter[i];
                    Console.Error.WriteLine(output[i]);
                }
            }

            foreach (var line in output)
                Console.WriteLine(line);
        }

        
    }
}
