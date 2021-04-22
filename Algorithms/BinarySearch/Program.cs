using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms_intro
{
    class Program
    {
        private const int NotFound = -1;
        static void Main(string[] args)
        {
            int[] coins = new[] { 5, 1, 2, 4, 3};

            SelectionSort(coins);
           int index =  BinarySearch(coins, 2, 0, coins.Length - 1);

            Console.WriteLine(index);
       
        }
        public static int BinarySearch(int[] arr, int search, int left, int right)
        {
            //While i still have more than one element in the subset

            while (right >= left)
            {
                int midIndex = (left + right) / 2;

                if (search > arr[midIndex])
                {
                    left = midIndex + 1;
                }
                else if (search < arr[midIndex])
                {
                    right = midIndex - 1;
                }
                else
                {
                    return midIndex;
                }
               
            }

            return NotFound;
        }
        public static void BubbleSort(int[] arr) // not in use
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
        } 

        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
