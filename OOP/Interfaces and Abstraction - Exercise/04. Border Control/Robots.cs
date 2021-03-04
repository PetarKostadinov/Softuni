using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robots : IIdentification
    {
        private string model;
        public Robots(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }
        public string Id { get; }
    }
}
