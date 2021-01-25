using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EvenLines
{
    class StartUp
    {
        static void Main(string[] args)
        {  
            using StreamReader reader = new StreamReader("../../../Text.txt");
            {
                string line = reader.ReadLine();
                int lineCounter = 0;

                while (line != null)
                {
                    //line.Replace('-', '@');
                    //line.Replace(',', '@');
                    //line.Replace('.', '@');
                    //line.Replace('!', '@');
                    //line.Replace('?', '@');
                    //line.Replace('-', '@');
                    // or Regex =>

                    if (lineCounter % 2 == 0)
                    {
                        Regex patern = new Regex("[-,.!?]");

                        line = patern.Replace(line, "@");

                        var array = line.Split().ToArray().Reverse();

                        Console.WriteLine(string.Join(" ", array));
                    }

                    lineCounter++;

                    line = reader.ReadLine();
                }
            }
        }
    }
}
