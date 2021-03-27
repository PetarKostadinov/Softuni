using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
                
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            var instrument = dwarf.Instruments.FirstOrDefault(x => x.IsBroken() == false);

            while (present.IsDone() == false && dwarf.Energy > 0 && instrument != null)
            {
                present.GetCrafted();
                instrument.Use();
                dwarf.Work();


                if (instrument.IsBroken())
                {
                    
                    instrument = dwarf.Instruments.FirstOrDefault(x => x.IsBroken() == false);
                }
            }


        }
    }
}
