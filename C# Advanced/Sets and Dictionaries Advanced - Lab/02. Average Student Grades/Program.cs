using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!students.ContainsKey(input[0]))
                {
                    students.Add(input[0], new List<decimal>());
                    students[input[0]].Add(decimal.Parse(input[1]));
                }
                else
                {
                    students[input[0]].Add(decimal.Parse(input[1]));
                }
            }
            foreach (var grades in students)
            {
                Console.Write($"{grades.Key} -> ");
                foreach (var number in grades.Value)
                {
                    Console.Write($"{ number:F2} ");

                }

                Console.Write($"(avg: { grades.Value.Average():F2})");
                Console.WriteLine();
            }
        }
    }
}
