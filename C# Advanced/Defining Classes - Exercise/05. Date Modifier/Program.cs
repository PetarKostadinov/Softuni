using System;

namespace DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            var result = dateModifier.GetTimeDiference(startDate, endDate);

            Console.WriteLine(result);
        }
    }
}
