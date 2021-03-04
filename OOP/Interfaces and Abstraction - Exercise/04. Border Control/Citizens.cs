using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IIdentification
    {
        private string name;
        private int age;
        public Citizens(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }
        public string Id { get; private set; }
    }
}
