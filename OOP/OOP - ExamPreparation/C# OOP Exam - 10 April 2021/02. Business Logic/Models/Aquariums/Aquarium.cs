using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        
        private List<IDecoration> decorations;
        private List<IFish> fish;
        

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
         
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();

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
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity { get; private set; }
      

        public int Comfort => this.decorations.Sum(x => x.Comfort);
       

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            string names = this.fish.Count == 0 ? "none" : string.Join(", ", this.fish.Select(x => x.Name));

            sb.AppendLine($"Fish: { names}");
            sb.AppendLine($"Decorations: { this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
           return this.fish.Remove(fish);
        }
    }
}
