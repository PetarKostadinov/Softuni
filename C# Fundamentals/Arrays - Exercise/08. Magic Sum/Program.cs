using System;
using System.Collections.Generic;
using System.Linq;


namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int[]> test = new Dictionary<string, int[]>();



            test["petar"] = new int[] { 1, 2, 3, 4, 5, 6 };

            foreach (var item in test)
            {
                Console.WriteLine($"{item.Key} <>");

                foreach (var val in item.Value)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
}
