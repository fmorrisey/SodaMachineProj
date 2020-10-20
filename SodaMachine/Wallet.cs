using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The customer's wallet will hold the List<Coins> and card
    /// </summary>
    class Wallet
    {
        // Member Variables
        public List<Coin> coins;
        public Card card;
        // Ctor
        public Wallet()
        {
            coins = new List<Coin>(); //coins in the customer's possession
            card = new Card();

        }

        // Member Methods
    }
}
