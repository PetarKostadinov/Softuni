using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizens : IIdentification, IType, IBirthdates
    {
        private string name;
        private int age;
        public Citizens(string type, string name, int age, string id, string birthdate)
        {
            this.Type = type;
            this.name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public string Id { get; private set; }

        public string Type { get; private set; }

        public string Birthdate { get; private set; }
    }
}
