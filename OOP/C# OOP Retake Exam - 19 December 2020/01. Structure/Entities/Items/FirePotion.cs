using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int weight = 5;
        public FirePotion()
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            if (character.IsAlive)
            {
                character.Health -= 20;

                if (character.Health <= 0)
                {
                    character.Health = 0;
                    character.IsAlive = false;
                }
            }
        }
    }
}
