using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {    
        private IRepository<IGun> GunRepository;
        private IRepository<IPlayer> PlayerRepository;
        private IMap map;

        public Controller()
        {
            this.GunRepository = new GunRepository();
            this.PlayerRepository = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;

            gun = TryCreateGun(type, name, bulletsCount, gun);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            GunRepository.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            IGun gun = this.GunRepository.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }

            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.PlayerRepository.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.PlayerRepository.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username))
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
           return this.map.Start(this.PlayerRepository.Models.ToList());
        }

        private static IGun TryCreateGun(string type, string name, int bulletsCount, IGun gun)
        {
            if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }

            return gun;
        }
    }
}
