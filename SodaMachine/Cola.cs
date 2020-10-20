using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class Cola : Can
    {
        // Member Variables

        // Ctor
        public Cola()
        {
            this.Name = "Cola";
            //this.Cost = 0.35d; // cents per can +Public
            this.cost = 0.35d; // cents per can #Protected
        }

        // Member Methods
    }
}
