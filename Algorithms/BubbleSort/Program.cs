using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = new[] { 5, 1, 2, 4, 3};

            BubbleSort(coins);

            Console.WriteLine(String.Join(", ", coins));
       
        }

        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        Swap(arr, i, j);
                    }
                }
            }
        }

        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j; 
                    }
                }

                Swap(arr, i, min);
            }
        } // not in use

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
