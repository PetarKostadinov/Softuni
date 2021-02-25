using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                List<string> input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < input.Count; i++)
                {
                    var inputPerson = input[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();

                    string name = inputPerson[0];
                    int money = int.Parse(inputPerson[1]);

                    people.Add(new Person(name, money));
                }

                List<string> data = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < data.Count; i++)
                {
                    var inputProduct = data[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToList();

                    string name = inputProduct[0];
                    int price = int.Parse(inputProduct[1]);

                    products.Add(new Product(name, price));
                }

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "END")
                    {
                        break;
                    }

                    List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                    string personName = commands[0];
                    string productName = commands[1];

                    Person person = people.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    person.AddToBag(product);
                }

                foreach (var personResult in people)
                {
                    Console.WriteLine(personResult);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
