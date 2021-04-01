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
        private double baseHealth;
        private double healt;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;

        protected Character(string name, double healt, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = baseHealth;
            Healt = healt;
            BaseArmor = baseArmor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            AbilityPoints = abilityPoints;
            Bag = bag;
            
    }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth
        {
            get { return this.baseHealth; }
            private set { this.baseHealth = value; }
        }

        public double Healt
        {
            get { return this.healt; }
             set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                this.healt = value;
            }
        }

        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set { this.baseArmor = value; }
        }

        public double Armor
        {
            get { return this.armor; }
             set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.armor = value;
            }
        }
        


        public double AbilityPoints
        {
            get { return abilityPoints; }
            set { abilityPoints = value; }
        }

        public Bag Bag { get; private set; }


        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor >= hitPoints)
                {
                    this.Armor -= hitPoints;
                }
                else
                {
                    hitPoints -= this.Armor;
                    this.Armor = 0;
                    this.Healt -= hitPoints;

                }
            }
        }

        void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

    }
}