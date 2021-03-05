using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pets : IBirthdates, IType
    {
        private string type;
        private string name;

        public Pets(string type, string name, string birthdate)
        {
            this.Type = type;
            this.name = name;
            this.Birthdate = birthdate;
        }
        public string Birthdate { get; private set; }

        public string Type { get; private set; }
    }
}
