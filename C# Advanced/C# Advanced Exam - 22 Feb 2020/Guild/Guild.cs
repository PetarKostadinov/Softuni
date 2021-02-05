using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
   public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Capacity > roster.Count)
            {
                this.roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var nameToRemove = this.roster.FirstOrDefault(x => x.Name == name);

            if (nameToRemove != null)
            {
                this.roster.Remove(nameToRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var nameToUse = this.roster.FirstOrDefault(x => x.Name == name);

            if (nameToUse != null && nameToUse.Rank != "Member")
            {
                nameToUse.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var nameToUse = this.roster.FirstOrDefault(x => x.Name == name);

            if (nameToUse != null && nameToUse.Rank != "Trial")
            {
                nameToUse.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] array = this.roster.Where(x => x.Class == @class).ToArray();

            this.roster = this.roster.Where(x => x.Class != @class).ToList();

            return array;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in roster)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
