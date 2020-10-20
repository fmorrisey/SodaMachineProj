using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Dime : Coin
    {
        // Member Variables

        // Ctor
        public Dime()
        {
            this.Name = "Dime";
            //this.Value = 0.10d; // cents +Public
            this.value = 0.10d; // cents #Protected
        }

        // Member Methods
    }
}
