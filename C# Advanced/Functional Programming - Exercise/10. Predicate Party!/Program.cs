using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> lengthFunc = (name, length) => name.Length == length;

            Func<string, string, bool> startsWithFunc = (name, startsWithString) => name.StartsWith(startsWithString);

            Func<string, string, bool> endsWith = (name, endsWithString) => name.EndsWith(endsWithString);

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] comandInfo = command.Split();
                string action = comandInfo[0];
                string condition = comandInfo[1];
                string param = comandInfo[2];

                if (action == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);

                       var tempNames = names.Where(x => lengthFunc(x, length)).ToList();

                        MyAddMethod(names, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        var tempNames = names.Where(name => startsWithFunc(name, param)).ToList();

                        MyAddMethod(names, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        var tempNames = names.Where(name => endsWith(name, param)).ToList();

                        MyAddMethod(names, tempNames);
                    }
                }
                else if (action == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(param);

                        names = names.Where(x => !lengthFunc(x, length)).ToList();

                    }
                    else if (condition == "StartsWith")
                    {
                        names = names.Where(name => !startsWithFunc(name, param)).ToList();

                    }
                    else if (condition == "EndsWith")
                    {
                        names = names.Where(name => !endsWith(name, param)).ToList();

                    
                    }
                }
              
                    command = Console.ReadLine();
            }
            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void MyAddMethod(List<string> names, List<string> tempNames)
        {
            foreach (var currNames in tempNames)
            {
                int index = names.IndexOf(currNames);

                names.Insert(index, currNames);
            }
        }
    }
}
