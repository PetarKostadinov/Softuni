using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int weight = 5;
        
        public HealthPotion() 
            : base(weight)
        {

        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (character.IsAlive)
            {
                character.Health += 20;
            }
        }
    }
}
