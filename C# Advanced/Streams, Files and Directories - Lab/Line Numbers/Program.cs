using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../OutputText.txt"))
                {

                    string line = reader.ReadLine();
                    int counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        Console.WriteLine($"{counter}. {line}");

                        counter++;

                        line = reader.ReadLine();
                    }
                }

              
            }
        }
    }
}
