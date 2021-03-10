using System;
using System.Collections.Generic;
using MilitaryElite.Enumerations;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }

       State State { get; }

        public void CompleteMission();
    }
}
