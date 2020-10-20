using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// this class will instantiate the SodaMachine and Customer Objs
    /// </summary>
    class Simulation
    {
        // Member Variables
        public SodaMachine sodaMachine;
        public Customer customer;
        // Ctor
        public Simulation()
        {
            sodaMachine = new SodaMachine(); // SodaMachine Object exists here.
            customer = new Customer(); // Customer object, with it's wallet, coins, card, and backpack exists here.
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
