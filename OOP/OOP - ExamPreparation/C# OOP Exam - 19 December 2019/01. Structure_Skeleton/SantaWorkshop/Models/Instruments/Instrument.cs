using SantaWorkshop.Models.Instruments.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Instruments
{
    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power 
        {
            get
            {
               return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken()
        {
            bool isbroken = false;

            if (this.Power == 0)
            {
                isbroken = true;
            }

            return isbroken;
        }

        public void Use()
        {
            this.Power -= 10;
        }
    }
}
