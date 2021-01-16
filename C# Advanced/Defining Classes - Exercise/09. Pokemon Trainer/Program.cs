using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0].Equals("Tournament"))
                {
                    break;
                }

                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealt = int.Parse(input[3]);

                if (trainers.Any(x => x.Name.Equals(trainerName)))
                {
                    Trainer tempTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);

                    int index = trainers.IndexOf(tempTrainer);

                    trainers[index].CollectionOfPokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealt));
                    continue;
                }

                trainers.Add(new Trainer(trainerName,new List<Pokemon>()));

                trainers[trainers.Count - 1].CollectionOfPokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealt));
               
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Equals("End"))
                {
                    break;
                }

                if (command.Equals("Fire"))
                {
                    Trainer.PokemonAtak(trainers, command);
                }
                else if (command.Equals("Water"))
                {
                    Trainer.PokemonAtak(trainers, command);
                }
                else if (command.Equals("Electricity"))
                {
                    Trainer.PokemonAtak(trainers, command);
                }

            }
            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count()}");
            }
        }
    }
}
