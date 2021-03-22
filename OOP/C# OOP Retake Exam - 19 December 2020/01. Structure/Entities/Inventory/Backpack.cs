using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag, IBag
    {
        public Backpack() 
            : base(100)
        {
        }
    }
}
