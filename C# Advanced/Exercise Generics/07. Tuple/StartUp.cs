

namespace Generics
{
    using System;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPersonInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] inputBeer = Console.ReadLine().Split();

            string[] inputNumbersInfo = Console.ReadLine().Split();

            string fulName = inputPersonInfo[0] + ' ' + inputPersonInfo[1];
            string adres = inputPersonInfo[2];

            string name = inputBeer[0];
            int liters = int.Parse(inputBeer[1]);

            int myInt = int.Parse(inputNumbersInfo[0]);
            double myDouble = double.Parse(inputNumbersInfo[1]);

            var personInfo = new MyTuple<string, string>(fulName, adres);
            var beer = new MyTuple<string, int>(name, liters);
            var numbersInfo = new MyTuple<int, double>(myInt, myDouble);

            Console.WriteLine(personInfo);
            Console.WriteLine(beer);
            Console.WriteLine(numbersInfo);
        }
    }
}
