
using System;
using System.Runtime.Serialization;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsExceptions : Exception
    {

        private const string DEF_EXC_MSG = "Invalid corps";
        public InvalidCorpsExceptions()
            : base(DEF_EXC_MSG)
        {
        }

        public InvalidCorpsExceptions(string message) 
            : base(message)
        {
        }
    }
}
