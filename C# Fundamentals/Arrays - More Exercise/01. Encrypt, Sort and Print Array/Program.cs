using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[] vowels = new char[] { 'E', 'e', 'U', 'u', 'I', 'i', 'O', 'o', 'A', 'a' };

            int[] results = new int[n];

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                string name = Console.ReadLine();

                for (int j = 0; j < name.Length; j++)
                {
                    char currIndex = name[j];

                    if (vowels.Any(x => x == name[j]))
                    {
                        sum += currIndex * name.Length;
                    }
                    else
                    {
                        sum += currIndex / name.Length;

                    }
                }

                results[i] = sum;
            }

            Console.WriteLine(string.Join(Environment.NewLine, results.OrderBy(x=>x)));           
        }       
    }
}