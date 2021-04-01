using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private int load;
        private readonly ICollection<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.Load = load;
            this.items = new List<Item>();

        }

       

        public int Capacity { get; set; }

        public int Load 
        {
            get
            {
                return this.load;
            }
            private set
            {
                value = this.Items.Sum(x => x.Weight);

                this.load = value;
            }
        }

        public IReadOnlyCollection<Item> Items => this.Items;

        

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Load == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var existingItem = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (existingItem == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(existingItem);

            return existingItem;
        }
    }
}
