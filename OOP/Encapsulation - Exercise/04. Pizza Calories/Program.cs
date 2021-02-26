using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {

            try
            {
                string pizzaNmae = Console.ReadLine().Split()[1];
                string[] input = Console.ReadLine().Split().ToArray();

                string flourType = input[1];
                string backingTech = input[2];
                double weight = double.Parse(input[3]);

                Dough dough = new Dough(flourType, backingTech, weight);

                Pizza pizza = new Pizza(pizzaNmae, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] inputToping = command.Split().ToArray();

                    string topingType = inputToping[1];
                    double topingWeight = double.Parse(inputToping[2]);

                    Topping toping = new Topping(topingType, topingWeight);

                    pizza.AddTopping(toping);

                    command = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception exeception)
            {

                Console.WriteLine(exeception.Message);
            }

        }
    }
}
