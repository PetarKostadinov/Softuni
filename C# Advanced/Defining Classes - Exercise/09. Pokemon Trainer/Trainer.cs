using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {

        public Trainer(string name, List<Pokemon> collectionOfPokemon)
        {
            this.Name = name;
            this.CollectionOfPokemons = collectionOfPokemon;
            this.NumberOfBadges = 0;
        }
        public Trainer(string name, int numberOfBadges, List<Pokemon> collectionOfPokemon)
        {
            this.Name = name;
           this.NumberOfBadges = 0;
          this.CollectionOfPokemons = collectionOfPokemon;
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }

        public static void PokemonAtak(List<Trainer> trainers, string commad)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.CollectionOfPokemons.Any(x => x.Elelment == commad))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    int index = -1;

                    foreach (var pokemon in trainer.CollectionOfPokemons)
                    {
                        pokemon.Health -= 10;

                        if (pokemon.Health <= 0)
                        {
                            index = trainer.CollectionOfPokemons.IndexOf(pokemon);
                        }
                    }
                    if (index != -1)
                    {
                        trainer.CollectionOfPokemons.RemoveAt(index);
                    }
                }
            }

            
        }
    }
}
