using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);

            }

            if (aquarium == null)
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            this.aquariums.Add(aquarium);

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            if (decorationType == "Plant")
            {
                decoration = new Plant();

            }

            if (decoration == null)
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            this.decorations.Add(decoration);

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            
            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);

            }

            if (fish == null)
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            if (aquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                aquarium.AddFish(fish);

               return $"Successfully added {fishType} to {aquariumName}.";
            }

            if (aquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                aquarium.AddFish(fish);

                return $"Successfully added {fishType} to {aquariumName}.";
            }
            return "Water not suitable.";
        }

        public string CalculateValue(string aquariumName)
        {
           var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var total = aquarium.Fish.Sum( x => x.Price) + aquarium.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {total:f2}.";

        }

        public string FeedFish(string aquariumName)
        {
           var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();
            var count = aquarium.Fish.Count;

            return  $"Fish fed: {count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            this.aquariums.FirstOrDefault(x => x.Name == aquariumName).AddDecoration(decoration);

            this.decorations.Remove(decoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            this.aquariums.ToList().ForEach(x => sb.AppendLine(x.GetInfo()));

            return sb.ToString().TrimEnd();
        }
    }
}
