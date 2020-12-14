using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            short firstEmp = short.Parse(Console.ReadLine());
            short secondEmp = short.Parse(Console.ReadLine());
            short thirdEmp = short.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            short time = 0;

            int togetherForHour = firstEmp + secondEmp + thirdEmp;



            while (peopleCount > 0)
            {
                time++;

                if (time % 4 == 0)
                {

                    continue;

                }

                peopleCount -= togetherForHour;

            }


            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
