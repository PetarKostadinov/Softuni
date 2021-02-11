﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
   public class Person : IComparable<Person>
    {
        public Person(string nmae, int age, string town)
        {
            this.Name = nmae;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull]Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            if (this.Age.CompareTo(other.Age) != 0)
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);
        }
    }
}
