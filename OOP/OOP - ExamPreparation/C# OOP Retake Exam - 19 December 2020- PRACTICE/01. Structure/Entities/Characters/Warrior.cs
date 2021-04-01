using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name)
            : base(name, 100, 50, 40, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (character.IsAlive && this.IsAlive)
            {
                if (character == this)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                if (character.Armor >= this.AbilityPoints)
                {
                    character.Armor -= this.AbilityPoints;
                }
                else
                {
                    this.AbilityPoints -= character.Armor;
                    character.Armor = 0;
                    character.Healt -= this.AbilityPoints;

                    if (character.Healt < 0)
                    {
                        character.Healt = 0;
                        character.IsAlive = false;
                    }
                }

                
            }
        }
    }
}
