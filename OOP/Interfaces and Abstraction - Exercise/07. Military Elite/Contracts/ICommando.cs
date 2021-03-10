using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Misions { get; }

        void AddMissions(IMission mission);
    }
}
