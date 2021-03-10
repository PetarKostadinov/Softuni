using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionCompletionEception : Exception
    {

        private const string DEF_EXC_MSG = "Mission already completed!";
        public InvalidMissionCompletionEception()
            : base(DEF_EXC_MSG)
        {

        }

        public InvalidMissionCompletionEception(string message) 
            : base(message)
        {
        }
    }
}
