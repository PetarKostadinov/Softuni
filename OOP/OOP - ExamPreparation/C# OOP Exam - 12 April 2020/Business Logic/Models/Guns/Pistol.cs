using CounterStrike.Models.Guns.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < 1)
            {
                return 0;
            }

            this.BulletsCount -= 1;

            return 1; 

        }
    }
}
