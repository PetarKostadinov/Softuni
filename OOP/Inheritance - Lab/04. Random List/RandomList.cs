using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public RandomList()
        {
            this.random = random;
        }

        public  Random random { get; set; }

        public string RandomString()
        {
            int index = random.Next(0, this.Count);

            string itemToRemove = this[index];

            this.RemoveAt(index);

            return itemToRemove;
        }
    }
}
