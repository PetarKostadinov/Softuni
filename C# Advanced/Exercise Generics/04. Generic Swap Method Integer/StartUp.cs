﻿using System;
using System.Linq;

namespace Generics
{
   public class StartUp
    {
        static void Main(string[] args)
        {     
            int n = int.Parse(Console.ReadLine());

            Box<int> box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                box.Value.Add(input);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int a = indexes[0];
            int b = indexes[1];

            box.Swap(a, b);
            Console.WriteLine(box);
        }
    }
}
