using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int firstNum = array[0];

                for (int j = +1; j < array.Length; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstNum;
            }
            Console.WriteLine(string.Join(" ", array));


        }
    }
}
