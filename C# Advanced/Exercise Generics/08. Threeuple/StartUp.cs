

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

            string[] inputBankInfo = Console.ReadLine().Split();

            string fulName = inputPersonInfo[0] + ' ' + inputPersonInfo[1];
            string adres = inputPersonInfo[2];
            string town = inputPersonInfo[3];


            string name = inputBeer[0];
            int liters = int.Parse(inputBeer[1]);
            string type = inputBeer[2];

            bool isDrunk = type == "drunk" ? true : false;
           
            string personName = inputBankInfo[0];
            double balance = double.Parse(inputBankInfo[1]);
            string bankName = inputBankInfo[2];

            var personInfo = new Threeuple<string, string, string>(fulName, adres, town);

            var beerInfo = new Threeuple<string, int, bool>(name, liters, isDrunk);

            var bankInfo = new Threeuple<string, double, string>(personName, balance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(bankInfo);

        }

          
    }
}
