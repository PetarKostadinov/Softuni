using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IIdentification, IType
    {
        private string model;
        public Robots(string type, string model, string id)
        {
            this.Type = type;
            this.model = model;
            this.Id = id;
        }
        public string Id { get; }

        public string Type { get; private set; }
    }
}
