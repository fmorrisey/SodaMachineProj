using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    class OrangeSoda : Can
    {
        // Member Variables

        // Ctor
        public OrangeSoda()
        {
            this.Name = "Orange Soda";
            this.Cost = 0.06d; // cents per can +Public
            this.cost = 0.06d; // cents per can #Protected
        }

        // Member Methods
    }
}
