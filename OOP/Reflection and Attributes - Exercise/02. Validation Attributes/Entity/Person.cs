using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Entity
{
    public class Person : MyRequiredAttribute
    {
        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;

        public Person(string fullName, int age)
        {
            this.FullNmae = fullName;
            this.Age = age;
        }
        [MyRequired]
        public string FullNmae { get; set; }
        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; set; }
    }
}
