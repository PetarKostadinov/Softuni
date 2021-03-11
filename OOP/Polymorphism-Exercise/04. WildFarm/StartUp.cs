using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int counter = -1;
            Animal animal = null;

            List<Animal> collection = new List<Animal>();

            while (true)
            {
                counter++;
                string line = Console.ReadLine();
                string[] parts = line.Split();

                if (line == "End")
                {
                    break;
                }

                if (counter % 2 == 0)
                {

                    animal = CreateAnimal(parts);

                    collection.Add(animal);
                }
                else
                {
                    Food food = null;
                    food = CreateFood(parts, food);

                    Console.WriteLine(animal.ProduceSound());

                    try
                    {
                        animal.Eat(food);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (var animalColected in collection)
            {
                Console.WriteLine(animalColected);
            }
        }

        private static Food CreateFood(string[] parts, Food food)
        {
            string foodType = parts[0];
            int quantity = int.Parse(parts[1]);


            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string[] parts)
        {
            Animal animal = null;

            string type = parts[0];
            string name = parts[1];
            double weight = double.Parse(parts[2]);

            if (type == "Hen")
            {
                double wingSize = double.Parse(parts[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Owl")
            {
                double wingSize = double.Parse(parts[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegion = parts[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = parts[3];

                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == "Cat")
            {
                string livingRegion = parts[3];
                string breed = parts[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = parts[3];
                string breed = parts[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
