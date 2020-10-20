using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class RootBeer : Can
    {
        // Member Variables

        // Ctor
        public RootBeer()
        {
            this.Name = "Root Beer";
            this.Cost = 0.60d; // cents per can +Public
            this.cost = 0.60d; // cents per can #Protected
        }

        // Member Methods
    }
}
