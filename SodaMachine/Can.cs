using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The Parent class of the soda flavors
    /// </summary>
    public abstract class Can
    {
        // Member Variables
        protected double cost;
        public double Cost { get => cost; }
        public string Name;

        // Ctor
        public Can()
        {

        }

        // Member Methods
    }
}
