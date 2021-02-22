using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) 
            : base(name, age)
        {
            
        }

        public int ChildAge 
        {
            get
            {
                return this.Age;
            }
            set
            {
                if (value < 0 && value > 15)
                {
                    throw new Exception();
                }

                this.ChildAge = value;
            }
        }
    }
}
