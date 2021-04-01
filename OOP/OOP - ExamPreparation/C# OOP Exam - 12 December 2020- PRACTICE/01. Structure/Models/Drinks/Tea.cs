using Bakery.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Drinks.Models
{
    public class Tea : Drink
    {
        private const decimal teaPrice = 2.50m;
        public Tea(string name, int portion, string brand) 
            : base(name, portion, teaPrice, brand)
        {
        }
    }
}
