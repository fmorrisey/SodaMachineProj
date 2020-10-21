using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private double avalibleCoinage;

        // Properties
        public double AvalibleCoinage
        {
            get { return avalibleCoinage; }                     // the get accessors returns the value 
        }


        // Ctor
        public Wallet()
        {
            coins = new List<Coin>();                               // coins in the customer's possession
            card = new Card();
            FillPocketsWithCoins(5, 2, 2, 5);                       // fill the customer's pockets with coins
            this.avalibleCoinage = WalletCoinReconciliation();      // sets the avalibleCoinage based on what's in the customer's wallet
            Console.WriteLine($"${card.AvailableFunds} on card");   // tells the user how much is in their debt account
        }

        // Member Methods
        private void FillPocketsWithCoins(int quarters, int dimes, int nickles, int pennies) // Adds coins to the register
        {
            for (int i = 0; i < quarters; i++) { coins.Add(new Quarter()); }
            for (int i = 0; i < dimes; i++) { coins.Add(new Dime()); }
            for (int i = 0; i < nickles; i++) { coins.Add(new Nickle()); }
            for (int i = 0; i < pennies; i++) { coins.Add(new Penny()); }
        }

        private double WalletCoinReconciliation()
        {
            double CoinsTotal = 0.0;

            for (int i = 0; i < coins.Count; i++)
            {
                CoinsTotal += coins[i].Value;
            }
            CoinsTotal = Math.Round(CoinsTotal, 3);

            Console.WriteLine($"Wallet Coins Total:${CoinsTotal}");
            Thread.Sleep(2000);
            return CoinsTotal;
        }
        /*
        public void AddMoney(double amountToAdd)
        {
            availableFunds += amountToAdd;
        }

        public bool RemoveMoney(double amountToRemove)
        {
            bool sufficientFunds;
            if (coins.Count <= 0)
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
        */
    }
}
