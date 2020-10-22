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
        private double totalAvaliableCoinage;
        private int[] coinageInventory;

        // Properties
        public double TotalAvaliableCoinage
        {
            get { return totalAvaliableCoinage; }                    // the get accessors returns the value 
        }

        public int[] CoinageInventory
        {
            get { return coinageInventory; }                        // the get accessors returns the value 
        }

        // Constructor
        public Wallet()
        {
            coins = new List<Coin>();                               // coins in the customer's possession
            card = new Card();
            
            FillPocketsWithCoins(12, 15, 7, 15);                    // fill the customer's pockets with coins with $5
            
            this.totalAvaliableCoinage = WalletCoinReconciliation();// sets the avalibleCoinage based on what's in the customer's wallet
            
            this.coinageInventory = new int[4];                     // Initializes the private array
            coinageInventory = TotalCoinageInventory();             // Adds the array to the public array
        }

        // Member Methods
        public void CheckWallet()
        {
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine("#### WHAT IN MY WALLET? ####");
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine($"Quarters: {CoinageInventory[0]}");
            Console.WriteLine($"Dimes: {CoinageInventory[1]}");
            Console.WriteLine($"Nickels: {CoinageInventory[2]}");
            Console.WriteLine($"Pennies: {CoinageInventory[3]}");
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine($"Wallet Coins Total: ${totalAvaliableCoinage}");
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine($"${card.AvailableFunds} on card");   // tells the user how much is in their debt account
            UserInterface.WaitForKey("Press ENTER to continue...", 500);
        }

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

            
            Thread.Sleep(2000);

            return CoinsTotal;
        }

        private int[] TotalCoinageInventory()
        {
            foreach (Coin coin in coins)
            {
                switch (coin.Value)
                {
                    case 0.01: // Penny
                        coinageInventory[0]++;
                        break;
                    case 0.05: // Nickel
                        coinageInventory[1]++;
                        break;
                    case 0.10: // Dime
                        coinageInventory[2]++;
                        break;
                    case 0.25: // Quarter
                        coinageInventory[3]++;
                        break;
                    default:
                        break;
                }
            }
                       

            Thread.Sleep(1000);
            return coinageInventory;
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
