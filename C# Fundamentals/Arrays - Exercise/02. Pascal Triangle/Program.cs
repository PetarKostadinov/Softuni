using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumVowels = 0;
            int sumConsonant = 0;
            int sum = 0;

            int[] arrayOfSums = new int[n];

            for (int i = 0; i < n; i++)
            {

                string name = Console.ReadLine();
                for (int j = 0; j < name.Length; j++)
                {
                    int currentLetter = name[j];

                    if (currentLetter == 97
                     || currentLetter == 101
                     || currentLetter == 105
                     || currentLetter == 111
                     || currentLetter == 117
                     || currentLetter == 65
                     || currentLetter == 69
                     || currentLetter == 73
                     || currentLetter == 79
                     || currentLetter == 85)
                    {
                        sumVowels += currentLetter * name.Length;
                    }
                    else
                    {
                        sumConsonant += currentLetter / name.Length;
                    }
                }
                sum = sumVowels + sumConsonant;
                arrayOfSums[i] = sum;

                sumVowels = 0;
                sumConsonant = 0;
                sum = 0;



            }

            Array.Sort(arrayOfSums);
            for (int i = 0; i < arrayOfSums.Length; i++)
            {
                Console.WriteLine(arrayOfSums[i]);
            }
        }
    }
}