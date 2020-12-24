using System;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] speedCounter = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double firsrtCarr = 0;
            double secondCarr = 0;
            

            int finishLine = (speedCounter.Length - 1) / 2;

            for (int i = 0; i < finishLine; i++)
            {
                firsrtCarr += speedCounter[i];

                if (speedCounter[i] <= 0)
                {
                    firsrtCarr *= 0.8;
                }


            }
            for (int i = speedCounter.Length - 1; i >= finishLine + 1; i--)
            {
                secondCarr += speedCounter[i];

                if (speedCounter[i] <= 0)
                {
                    secondCarr *= 0.8;
                }
            }

            double winer = 0;
            string firstOrSecond = string.Empty;

            if (firsrtCarr > secondCarr)
            {
                 winer = secondCarr;

                firstOrSecond = "right";
            }
            else
            {
                winer = firsrtCarr;

                firstOrSecond = "left";
            }

            Console.WriteLine($"The winner is {firstOrSecond} with total time: {winer}");
            
        }
    }
}
