using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Quarter : Coin
    {
        // Member Variables

        // Ctor
        public Quarter()
        {
            this.Name = "Quarter";
            this.Value = 0.25d; // cents +Public
            this.value = 0.25d; // cents #Protected
        }

        // Member Methods
    }

}
