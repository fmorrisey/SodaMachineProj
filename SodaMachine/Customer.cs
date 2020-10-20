using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// 
    /// </summary>
    class Customer
    {
        // Member Variables
        public Wallet wallet;
        public BackPack backPack;
        // Ctor
        public Customer()
        {
            wallet = new Wallet();
            backPack = new BackPack();
        }

        // Member Methods
    }
}
