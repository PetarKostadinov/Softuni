using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> items;
        public WarController()
        {
            this.characters = new HashSet<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = null;

            string wariorOrPriest = args[0];
            string name = args[1];

            if (wariorOrPriest == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (wariorOrPriest == "Priest")
            {
                character = new Priest(name);
            }
            else if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, wariorOrPriest));
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
            }
           


            this.characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Item item = null;

            string itemName = args[0];

            if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            items.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            var character = characters.FirstOrDefault(x => x.Name == name);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            var lastItem = items.LastOrDefault();

            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            character.Bag.AddItem(lastItem);
            items.Remove(lastItem);

            return string.Format(string.Format(SuccessMessages.PickUpItem, character.Name, lastItem.GetType().Name));
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);

            if (item == null)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            character.Bag.GetItem(itemName).AffectCharacter(character);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                string aliveOrDead = string.Empty;
                if (character.IsAlive)
                {
                    aliveOrDead = "Alive";
                }
                else
                {
                    aliveOrDead = "Dead";
                }

                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armour}/{character.BaseArmor}, Status: {aliveOrDead}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string receiverName = args[1];

            var attacker = (Warrior)characters.FirstOrDefault(x => x.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            var reciever = characters.FirstOrDefault(x => x.Name == receiverName);

            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            try
            {
                attacker.Attack(reciever);

                sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {reciever.Health}/{reciever.BaseHealth} HP and {reciever.Armour}/{reciever.BaseArmor} AP left!");

                if (!reciever.IsAlive)
                {
                    sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, reciever.Name));
                }

                return sb.ToString().TrimEnd();
            }
            catch(Exception)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            var healer = (Priest)this.characters.FirstOrDefault(x => x.Name == healerName);
            var receiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            try
            {
                healer.Heal(receiver);

                sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

                return sb.ToString().TrimEnd();
            }
            catch (Exception)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
        }
    }
}
