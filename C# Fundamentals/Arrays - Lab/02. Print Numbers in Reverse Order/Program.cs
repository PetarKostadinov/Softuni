using System;
using System.Linq;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] numbers = new int[num];

            for (int i = 0; i < num; i++)
            {
                numbers[i] = int.Parse (Console.ReadLine());

            }

            Console.WriteLine(string.Join(' ', numbers.Reverse()));

            //for (int j = numbers.Length - 1; j >= 0; j--)
            //{

            //    Console.Write(numbers[j] + " ");
            //}
           
        }
    }
}
