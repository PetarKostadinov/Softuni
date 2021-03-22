using System;
using System.Collections.Generic;
using System.Text;

namespace WarCroft.Entities.Inventory
{
    public class Satchel : Bag, IBag
    {
        public Satchel() : base(20)
        {
           
        }
    }
}
