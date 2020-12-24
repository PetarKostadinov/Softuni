using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtraExercise_TopInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            bool isBiger = true;

            for (long i = 0; i < inputArr.Length; i++)
            {
                int currInt = inputArr[i];


                for (long j = i + 1; j < inputArr.Length; j++)
                {
                    if (inputArr[j] >= currInt)
                    {
                        isBiger = false;
                        break;
                    }
                }
                if (isBiger)
                {
                    Console.Write(currInt + " ");
                }

                isBiger = true;

               
            }
        }
    }
}