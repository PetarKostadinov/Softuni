using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
   public class Box<T>
         where T : IComparable
    {
        public Box()
        {
            this.Value = new List<T>();
        }

        public List<T> Value { get; set; }

        public int isGreaterThan(T targetItem)
        {
            int counter = 0;

            foreach (var value in this.Value)
            {
                if (value.CompareTo(targetItem) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void Swap(int a, int b)
        {
            T tempValue = this.Value[a];
            this.Value[a] = this.Value[b];
            this.Value[b] = tempValue;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this.Value)
            {
                result.AppendLine($"{item.GetType()}: {item}");
            }

            return result.ToString().TrimEnd() ;
        }
    }
}
