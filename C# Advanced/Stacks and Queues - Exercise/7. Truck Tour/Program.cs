using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<int[]> queuePumps = new Queue<int[]>();

            int counter = 0;
            FeelFuel(count, queuePumps);

            while (true)
            {

                int fuelAmount = 0;
                bool foundPoint = true;

                //for (int i = 0; i < count; i++)
                //{
                //    int[] currPump = queuePumps.Dequeue();

                //    fuelAmount += currPump[0];

                //    if (fuelAmount < currPump[1])
                //    {
                //        foundPoint = false;
                //    }

                //    fuelAmount -= currPump[1];

                //    queuePumps.Enqueue(currPump);

                //}

                foreach (var pump in queuePumps)
                {
                    fuelAmount += pump[0];

                    if (fuelAmount < pump[1])
                    {
                        foundPoint = false;
                        break;
                    }

                    fuelAmount -= pump[1];
                }

                if (foundPoint)
                {
                    break;
                }

                counter++;

                queuePumps.Enqueue(queuePumps.Dequeue());
            }

            Console.WriteLine(counter);
        }

        private static void FeelFuel(int count, Queue<int[]> queuePumps)
        {
            for (int i = 0; i < count; i++)
            {
                int[] stations = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queuePumps.Enqueue(stations);
            }
        }
    }
}
