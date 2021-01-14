using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        //fields
        private string name;
        private int age;
        //constructors
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        public Person(int age)
        : this()
        {
            this.Age = age;
        }
        //properties
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        //methods
        public override string ToString()
        {
            return $"{this.name} {this.Age}";
        }
    }
}