using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public class FirePotion : Item
    {
        public FirePotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Healt -= 20;

            if (character.Healt <= 0)
            {
                character.Healt = 0;
                character.IsAlive = false;
            }
        }
    }
}
