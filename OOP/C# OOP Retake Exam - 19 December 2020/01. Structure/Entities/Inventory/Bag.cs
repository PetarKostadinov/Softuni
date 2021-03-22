using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {

        private ICollection<Item> items;
        private int load;
        

        public Bag(int capacity)
        {
            this.Load = load;
            this.items = new HashSet<Item>();
           
        }
        public int Capacity { get; set; } = 100;

        public int Load
        {
            get 
            {
                return this.load; 
            }
            set
            {
               this.load = this.Items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if (this.load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (this.items.GetType().Name != name)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag);
            }

            this.items.Remove(item);

            return item;
        }
    }
}
