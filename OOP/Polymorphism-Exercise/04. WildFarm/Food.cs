using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
