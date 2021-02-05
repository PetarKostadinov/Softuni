using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{

    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.Capacity > this.data.Count)
            {
                this.data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var givenName = this.data.FirstOrDefault(x => x.Name == name);

            if (givenName != null)
            {
                this.data.Remove(givenName);

                return true;
            }

            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            var getName = this.data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return getName;
        }
        public Pet GetOldestPet()
        {
            var oldest = this.data.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldest;
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("The clinic has the following patients:");

            foreach (var pet in data)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return result.ToString();
        }

    }
}
