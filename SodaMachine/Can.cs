using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The Parent class that the child classes of soda flavors inherit from
    /// </summary>
    public abstract class Can
    {
        // Member Variables
        protected double cost;
        public double Cost { get => cost; }
        public string Name;

        // CTOR
        public Can()
        {
            this.cost = cost;
        }

        // Member Methods
    }
}
