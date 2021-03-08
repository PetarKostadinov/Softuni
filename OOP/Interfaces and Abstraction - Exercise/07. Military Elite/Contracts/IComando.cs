using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IComando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Misions { get; }
    }
}
