using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "PARTY")
                {
                    break;
                }

                guests.Add(input);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                guests.Remove(input);
            }
            Console.WriteLine(guests.Count);

            HashSet<string> vipSetPrintedAndToBeRemoved = new HashSet<string>();

            foreach (var guest in guests)
            {    
                var vipGuest = guest.ToCharArray();

                if (Char.IsDigit(vipGuest[0]))
                {
                    Console.WriteLine(guest);
                    vipSetPrintedAndToBeRemoved.Add(guest);
                }
            }
            foreach (var guest in vipSetPrintedAndToBeRemoved)
            {
                guests.Remove(guest);

            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
