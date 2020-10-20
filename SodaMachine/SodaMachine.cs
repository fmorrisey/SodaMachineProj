﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// This class will hold the Register and Inventory Lists collections
    /// </summary>
    class SodaMachine
    {
        // Member Variables
        public List<Coin> register;
        public List<Can> inventory;
        // Ctor
        public SodaMachine()
        {
            register = new List<Coin>(); // add cans here
            inventory = new List<Can>(); // add soda here
        }

        // Member Methods
        public void IsPowerOn(bool isPowerOn)
        {
            if (isPowerOn == true) { Console.WriteLine("The Soda Machine is ON"); Thread.Sleep(1000); }
            else { Console.WriteLine("The Soda Machine is OFF"); Thread.Sleep(1000); }
            //return isPowerOn;
        }
    }
}
