using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<string> elements = command.Split().Skip(1).ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            while (command != "END")
            {
                try
                {
                    if (command == "Print")
                    {
                        listyIterator.Print();
                    }
                    else if (command == "Move")
                    {
                        bool result = listyIterator.Move();
                        Console.WriteLine(result);
                    }
                    else if (command == "HasNext")
                    {
                        bool result = listyIterator.HasNext();
                        Console.WriteLine(result);
                    }
                    else if (command == "PrintAll")
                    {
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
              

                command = Console.ReadLine();
            }
        }
    }
}
