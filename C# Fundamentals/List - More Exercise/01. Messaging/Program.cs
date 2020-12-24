using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            string inputString = Console.ReadLine();

            List<char> result = new List<char>();
            for (int i = 0; i < data.Count; i++)
            {
                string currentString = data[i];

                int index = 0;
                for (int j = 0; j < currentString.Length; j++)
                {
                    char currentElement = currentString[j];
                    int currentElementValue = int.Parse(currentElement.ToString());

                    index += currentElementValue;
                }

                index = index % inputString.Length;
                result.Add(inputString[index]);

                

                string firstPart = inputString.Substring(0, index);
                string secondPart = inputString.Substring(index + 1, inputString.Length - index - 1);

                string temproraryString = firstPart + secondPart;
                inputString = temproraryString;
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}