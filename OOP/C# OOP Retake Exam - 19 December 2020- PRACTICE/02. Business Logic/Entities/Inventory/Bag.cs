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
        private int defaultCapacity = 100;
        

        public Bag(int capacity)
        {
           
            this.items = new HashSet<Item>();
            this.Capacity = defaultCapacity;
           
        }
        public int Capacity { get; set; }

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
            var item = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);

            return item;
        }
    }
}
