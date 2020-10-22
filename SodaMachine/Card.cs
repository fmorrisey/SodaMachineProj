using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// Available funds pub/priv
    /// </summary>
    class Card
    {
        // Member Variables
        private double availableFunds;

        // Properties
        public double AvailableFunds
        {
            get { return availableFunds; }              // the get accessors returns the value 
                        
        }
        // Ctor
        public Card()
        {
            this.availableFunds = Math.Round(20.00, 2); //$20 USD available
        }

        // Member Methods

        public void AddMoney(double amountToAdd)
        {
            availableFunds += amountToAdd;
        }

        public bool SwipeCard(double amountToRemove)
        {
            bool sufficientFunds;
            if (availableFunds <= 0)
            {
                availableFunds = 0;
                sufficientFunds = false;
                return sufficientFunds;
            }
            else
            {
                availableFunds -= amountToRemove;
                sufficientFunds = true;
                return sufficientFunds;
            }
        }

    }
}
