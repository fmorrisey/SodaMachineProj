﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The parent abstract of the coins/currency used in the USA
    /// </summary>
    public abstract class Coin
    {
        // Member Variables
        protected double value;
        public double Value { get => value; }
        public string Name;
        // Ctor
        

        // Member Methods
    }
}
