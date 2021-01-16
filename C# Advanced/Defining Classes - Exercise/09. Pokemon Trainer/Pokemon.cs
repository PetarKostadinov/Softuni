using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string elelment, int health)
        {
            Name = name;
            Elelment = elelment;
            Health = health;
        }

        public string Name { get; set; }

        public string Elelment { get; set; }
        public int Health { get; set; }
    }
}
