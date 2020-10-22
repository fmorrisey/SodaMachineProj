using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The customer's funds are stored in this class with access
    /// controlled by the public properties
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

        public void UICoinPayment(double payment)
        {
            string displayPayment = Math.Round(payment, 3).ToString("0.00");
            UserInterface.Clear();
            UserInterface.MenuDecorators("starlong");

            Console.WriteLine("     #### Select your Payment ####");
            Console.WriteLine($"        | Soda costs: ${displayPayment} |");

            UserInterface.MenuDecorators("starlong");
            Console.WriteLine("Select the coins you would like to use: ");
            Console.WriteLine($"[1]Quarters: {CoinageInventory[0]}");
            Console.WriteLine($"[2]Dimes: {CoinageInventory[1]}");
            Console.WriteLine($"[3]Nickels: {CoinageInventory[2]}");
            Console.WriteLine($"[4]Pennies: {CoinageInventory[3]}");
            UserInterface.MenuDecorators("starlong");
        }
             

        //////////////////// FUNCTIONAL UTLILTIES //////////////////////
        /// These methods control wallet functions and payment handling
        public bool CheckCoins(double EnoughCoins)
        {
            bool sufficientFunds;
            if (totalAvaliableCoinage <= 0)
            {
                totalAvaliableCoinage = 0;
                sufficientFunds = false;
                return sufficientFunds;
            }
            else
            {
                totalAvaliableCoinage -= EnoughCoins;
                sufficientFunds = true;
                return sufficientFunds;
            }

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

        public void UpdateCoinageInventory()
        {   /// After the customer/user makes payment we need to 
            /// reconcile what is available for the next transaction
            totalAvaliableCoinage = WalletCoinReconciliation();
            coinageInventory = TotalCoinageInventory();
        }

        private int[] TotalCoinageInventory()
        {   /// Creates an array of the number of indviudal coins
            /// available to the customer/user ex; 7 Quarters
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


    }
}
