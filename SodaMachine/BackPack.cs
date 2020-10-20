using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The Customer's backpack will hold the soda
    /// </summary>
    class BackPack
    {
        // Member Variables
        public List<Can> cans;
        // Ctor
        public BackPack()
        {
            cans = new List<Can>(); //customer's soda in the backpack
        }

        // Member Methods
    }
}
