using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;
        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            SeparatePlayersAndAddThemToCollection(players);

            while (true)
            {
                AttackerShootDefender(terrorists, counterTerrorists);
                AttackerShootDefender(counterTerrorists, terrorists);

                if (!IsTeamAlive(terrorists))
                {
                    return "Counter Terrorist wins!";
                }
                if (!IsTeamAlive(counterTerrorists))
                {
                    return "Terrorist wins!";
                }
            }
        }

        private bool IsTeamAlive(List<IPlayer> players)
        {
            return players.Any(p => p.IsAlive);
        }
        private void SeparatePlayersAndAddThemToCollection(ICollection<IPlayer> players)
        {
            foreach (var terrorist in players
                .Where(x => x.GetType().Name == "Terrorist"))
            {
                this.terrorists.Add(terrorist);
            }

            foreach (var counterTerrorist in players
                .Where(x => x.GetType().Name == "CounterTerrorist"))
            {
                this.counterTerrorists.Add(counterTerrorist);
            }
        }

        private void AttackerShootDefender(ICollection<IPlayer> attackingTeam, ICollection<IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                foreach (var defender in defendingTeam)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }
    }
}
