using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Queue<int> plates = new Queue<int>(data);

            Stack<int> resultOrcs = new Stack<int>();

            bool orcsWining = false;

            int counter = numberOfWaves;
            int plate = 0;
            for (int i = 1; i <= numberOfWaves; i++)
            {
                counter--;
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                Stack<int> orcs = new Stack<int>(input);

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(extraPlate);
                }
                if (plates.Count > 0)
                {
                    plate = plates.Peek();
                }

                int orc = orcs.Peek();

                while (plates.Count > 0 && orcs.Count > 0)
                {
                    orc = orcs.Peek();
                    if (plate > orc)
                    {
                        plate -= orc;
                        orcs.Pop();
                    }
                    else if (orc > plate)
                    {
                        orc -= plate;
                        plates.Dequeue();
                        orcs.Pop();
                        orcs.Push(orc);
                        if (plates.Count > 0)
                        {
                            plate = plates.Peek();
                        }
                    }
                    else if (orc == plate)
                    {
                        plates.Dequeue();
                        orcs.Pop();
                        if (plates.Count > 0)
                        {
                            plate = plates.Peek();
                        }
                    }
                }
                int countOfOrcs = orcs.Count();
                if (orcs.Count > 0)
                {
                    orcsWining = true;
                    for (int j = 0; j < countOfOrcs; j++)
                    {
                        resultOrcs.Push(orcs.Pop());
                    }
                    break;
                }
            }
            if (!(plates.Count > 0 && resultOrcs.Count > 0))
            {
                if (orcsWining)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                    var allIn = new List<int>();
                    foreach (var item in resultOrcs.OrderBy(x => x))
                    {
                        allIn.Add(item);
                    }
                    Console.WriteLine($"Orcs left: {string.Join(", ", allIn)}");
                }
                else
                {
                    Console.WriteLine("The people successfully repulsed the orc's attack.");
                    Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
                }

                return;
            }
        }
    }
}
