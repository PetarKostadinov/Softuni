using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Drinks.Models
{
    public class Water : Drink
    {
        private const decimal waterPrice = 1.50m;
        public Water(string name, int portion, string brand) 
            : base(name, portion, waterPrice, brand)
        {
        }
    }
}
