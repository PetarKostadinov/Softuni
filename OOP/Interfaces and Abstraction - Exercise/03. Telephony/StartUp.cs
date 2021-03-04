using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var phoneNumbers = Console.ReadLine().Split().ToList();
            var webSites = Console.ReadLine().Split().ToList();
            var phone = new Smartphone();
            var statPhone = new StationaryPhone();

            foreach (var number in phoneNumbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(phone.Call(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(statPhone.Call(number));
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var webSite in webSites)
            {
                Console.WriteLine(phone.Browse(webSite));
            }
        }
    }
}
