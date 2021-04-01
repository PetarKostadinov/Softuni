using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {

        private DwarfRepository dwarfs;
        private PresentRepository presents;

        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf dwarf = null;
            if (dwarfType == "HappyDwarf")
            {
                dwarf = new HappyDwarf(dwarfName);
            }
            else if (dwarfType == "SleepyDwarf")
            {
                dwarf = new SleepyDwarf(dwarfName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }

            this.dwarfs.Add(dwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            IInstrument instrument = new Instrument(power);

            var dwarf = this.dwarfs.FindByName(dwarfName);
            if (dwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfName);
            }

            dwarf.AddInstrument(instrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            IPresent present = new Present(presentName, energyRequired);

            presents.Add(present);

            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            IDwarf dwarf = this.dwarfs.Models
                .OrderByDescending(x => x.Energy)
                .FirstOrDefault(x => x.Energy >= 50 && x.Instruments
                .Any(x => x.IsBroken() == false));

            var present = this.presents.FindByName(presentName);
            Workshop workshop = new Workshop();

            if (dwarf == null)
            {
                dwarf = this.dwarfs.Models
                .OrderByDescending(x => x.Energy)
                .FirstOrDefault(x => x.Energy >= 50);
            }

            if (dwarf == null)
            {

                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            workshop.Craft(present, dwarf);

            if (dwarf.Energy == 0)
            {
                this.dwarfs.Remove(dwarf);

            }

            if (present.IsDone() == false)
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (var present in this.presents.Models.Where(x => x.IsDone()))
            {
                counter++;
            }
            sb.AppendLine($"{counter} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in dwarfs.Models)
            {
                
                sb.AppendLine($"Name: {dwarf.Name}");
                sb.AppendLine($"Energy: {dwarf.Energy}");
                sb.AppendLine($"Instruments: {dwarf.Instruments.Where(x => x.Power > 0).Count()} not broken left");

            }

            return sb.ToString().TrimEnd();

        }
    }
}
