﻿using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {

        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
           this.Name = name;
           this.Species = species;
           this.Size = size;
           this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string Species
        {
            get
            {
                return this.species;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                this.species = value;
            }
        }

        public int Size { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                this.price = value;
            }
        }

        public abstract void Eat();
      
    }
}
