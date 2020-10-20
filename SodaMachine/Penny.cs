using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Penny : Coin
    {
        // Member Variables

        // Ctor
        public Penny()
        {
            this.Name = "Penny";
            //this.Value = 0.01d; // cents +Public
            this.value = 0.01d; // cents #Protected
        }

        // Member Methods
    }
}
