using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../Text.txt");

            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int countOfLetters = CountOfLetters(line);
                int countOfPunctuationMarks = CountOfPunctuationsMarks(line);

                newLines[i] = $"Line {i + 1}: {lines[i]} ({countOfLetters})({countOfPunctuationMarks})";

            }
            File.WriteAllLines("../../../output.txt", newLines);


        }
        static int CountOfLetters(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (Char.IsLetter(currSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
        static int CountOfPunctuationsMarks(string line)
        {
            char[] punctuationsmarks = { '-', ',', '!', '?', '\'', ':', ';', '.'};

            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currsymb = line[i];

                if (punctuationsmarks.Contains(currsymb))
                {
                    counter++;
                }

            }
            return counter;
        }
    }
}
