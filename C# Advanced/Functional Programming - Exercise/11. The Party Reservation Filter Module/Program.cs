using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine()
                 .Split()
                 .ToList();

            string input = Console.ReadLine();

            List<string> filters = new List<string>();

            while (input != "Print")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParam = tokens[2];

                if (command == "Add filter")
                {
                    filters.Add($"{filterType};{filterParam}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{filterType};{filterParam}");
                }

                input = Console.ReadLine();
            }

            foreach (var filterLine in filters)
            {
                string[] tokens = filterLine.Split(";");

                string filterType = tokens[0];
                string filterParam = tokens[1];

                switch (filterType)
                {
                    case "Contains":
                        names = names.Where(x => !x.Contains(filterParam)).ToList();
                        break;

                    case "Length":
                        names = names.Where(x => x.Length != int.Parse(filterParam)).ToList();
                        break;

                    case "Starts with":
                        names = names.Where(x => !x.StartsWith(filterParam)).ToList();
                        break;

                    case "Ends with":
                        names = names.Where(x => !x.EndsWith(filterParam)).ToList();
                        break;

                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
