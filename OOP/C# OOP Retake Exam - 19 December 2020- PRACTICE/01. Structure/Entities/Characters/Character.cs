using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double health;
        private double armour;
        protected Character(string name, double health, double armour, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armour;
            this.Armour = armour;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; set; }

        public double Health
        {
            get { return this.health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }

                if (value < 0)
                {
                    this.health = 0;
                }
                this.health = value;
            }
        }
        public double BaseArmor { get; set; }

        public double Armour
        {
            get { return this.armour; }
            set
            {
                if (value < 0)
                {
                    this.armour = 0;
                }
                this.armour = value;
            }
        }
        public double AbilityPoints { get; set; }

        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            double redusingPoints = this.Armour;

            if (IsAlive)
            {
                if (hitPoints <= this.Armour)
                {
                    this.Armour -= hitPoints;
                }
                else
                {
                    hitPoints -= this.Armour;
                    this.Armour = 0;
                    this.Health -= hitPoints;

                    if (this.Health <= 0)
                    {
                        this.Health = 0;
                        IsAlive = false;
                    }
                }
            }
        }
        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}