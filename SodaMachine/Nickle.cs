using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Nickle : Coin
    {
        // Member Variables

        // Ctor
        public Nickle()
        {
            this.Name = "Nickel";
            this.Value = 0.05d; // cents +Public
            this.value = 0.05d; // cents #Protected
        }

        // Member Methods
    }
}
