using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Coin> hands;
        public Card card;
        private double totalAvaliableCoinage;
        private int[] coinageInventory;

        public double coinSelectionTotal;
        public int[] transferCoins;


        // Properties
        public double TotalAvaliableCoinage
        {
            get { return totalAvaliableCoinage; }                    // the get accessors returns the value 
        }

        public int[] CoinageInventory
        {
            get { return coinageInventory; }                        // the get accessors returns the value 
        }

        public int[] UICoinInventory;                       //UI element that modifies a temporay array
        
        // Constructor
        public Wallet()
        {
            coins = new List<Coin>();                               // coins in the customer's possession
            card = new Card();
            hands = new List<Coin>();

            FillPocketsWithCoins(12, 15, 7, 15);                    // fill the customer's pockets with coins with $5
            //FillPocketsWithCoins(1, 1, 1, 0);                    // fill the customer's pockets with coins with $5

            this.totalAvaliableCoinage = WalletCoinReconciliation();// sets the avalibleCoinage based on what's in the customer's wallet

            this.coinageInventory = new int[4];                     // Initializes the private array
            coinageInventory = CreateCoinageInventory();            // Adds the array to the public array
            this.UICoinInventory = new int[4];
        }

        public void UICoinPayment(double paymentAmount)
        {
            string displayPayment = Math.Round(paymentAmount, 3).ToString("0.00");
            UserInterface.Clear();
            UserInterface.MenuDecorators("starlong");

            Console.WriteLine("     #### Select your Payment ####");
            Console.WriteLine($"        | Soda costs: ${displayPayment} |");

            UserInterface.MenuDecorators("starlong");
            Console.WriteLine("Select the coins you would like to use: ");
            Console.WriteLine("Press [5] when you're read to insert selected coins: ");
            UserInterface.MenuDecorators("star");
            Console.WriteLine($"[1] Quarters: {UICoinInventory[0]}");
            Console.WriteLine($"[2] Dimes: {UICoinInventory[1]}");
            Console.WriteLine($"[3] Nickels: {UICoinInventory[2]}");
            Console.WriteLine($"[4] Pennies: {UICoinInventory[3]}");
            UserInterface.MenuDecorators("star");
            Console.WriteLine($"[5] Insert selection\n");
            Console.WriteLine($"[6] Cancel ");
            UserInterface.MenuDecorators("starlong");

        }

        public void UICoinSelection(int[] CoinsInHand)
        {
            string displayCoin = Math.Round(coinSelectionTotal, 3).ToString("0.00");
            Console.WriteLine($"{transferCoins[0]} Quarters|{transferCoins[1]} Dimes|" +
                              $"{transferCoins[2]} Nickels|{transferCoins[3]} Pennies\n" +
                              $"Total of ${displayCoin} in hand");
        }

        public List<Coin> TransferCoins(double paymentAmount)
        {
            double coinSelection = 0;
            coinSelectionTotal = 0;
            bool finishedSelection = false;
            transferCoins = new int[4];
            Array.Copy(coinageInventory, UICoinInventory, 4);

            do
            {
                
                UICoinPayment(paymentAmount);
                UICoinSelection(transferCoins);
                coinSelection = UserInterface.IntInputValidation("Select your coins:");

                switch (coinSelection)
                {
                    case 1: // Add quarter to hand
                        transferCoins[0]++;
                        UICoinInventory[0]--;
                        coinSelectionTotal += 0.25;
                        hands.Add(new Quarter());
                        
                        break;

                    case 2: // add dime to hand
                        transferCoins[1]++;
                        UICoinInventory[1]--;
                        coinSelectionTotal += 0.10;
                        hands.Add(new Dime());
                        break;

                    case 3: // add nickel to hand
                        transferCoins[2]++;
                        UICoinInventory[2]--;
                        coinSelectionTotal += 0.05;
                        hands.Add(new Nickle());
                        break;

                    case 4: // add penny to hand
                        transferCoins[3]++;
                        UICoinInventory[3]--;
                        coinSelectionTotal += 0.01;
                        hands.Add(new Penny());
                        break;

                    case 5: // saves selection
                        finishedSelection = true;
                        //hands = hands.OrderByDescending(o => o.Value).ToList();
                        break;

                    case 6: // cancels transaction
                        Array.Clear(transferCoins, 0, transferCoins.Length);
                        hands.Clear();
                        finishedSelection = true;
                        break;
                    default:
                        Console.WriteLine("WALLET: SOMETHING'S NOT RIGHT HERE DAWG ");
                        break;
                }

            } while (finishedSelection != true); //ask again until user is finished
              
            return hands;

        }

        

        public void WalletContains(List<Coin> coinsInHand)
        {
            string coinName = "";
            for (int i = 0; i < coinsInHand.Count; i++)
            {
                coinName = coinsInHand[i].Name;
                SearchWallet(coinName);
            }         
        }

        private bool SearchWallet(string coinName)
        {
            foreach (Coin coin in coins) // Coins in hand
            {
                if (coin.Name == coinName)
                {
                    coins.Remove(coin);
                    return true;
                }
            }
            return false;
        }

        //////////////////// FUNCTIONAL UTLILTIES //////////////////////
        /// These methods control wallet functions and payment handling
        public bool CheckCoins(double EnoughCoins)
        {   // Checks before transaction for sufficient funds

            bool sufficientFunds;
            if (totalAvaliableCoinage <= 0) // If you're broke that's a nope
            {
                sufficientFunds = false;
                return sufficientFunds;
            }
            else if (totalAvaliableCoinage < EnoughCoins)
            { // If you have the coins, but not enough for the product
                sufficientFunds = false; // That'll be a No Dog
                return sufficientFunds;
            }
            else
            {   // If you have enough make payment
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

        public void ChangeReturn(List<Coin> coinsReturn) // Adds coins to the register
        {
            foreach (Coin coin in coinsReturn)
            {
                coins.Add(coin);
            }
        }

        private double WalletCoinReconciliation()
        {
            double CoinsTotal = 0.0;

            for (int i = 0; i < coins.Count; i++)
            {
                CoinsTotal += coins[i].Value;
            }
            CoinsTotal = Math.Round(CoinsTotal, 2);
            return CoinsTotal;
        }

        public void UpdateCoinageInventory()
        {   /// After the customer/user makes payment we need to 
            /// reconcile what is available for the next transaction

            coinageInventory = CreateCoinageInventory();
            totalAvaliableCoinage = WalletCoinReconciliation();

        }

        private int[] CreateCoinageInventory()
        {   /// Creates an array of the number of individual coins
            /// available to the customer/user ex; 7 Quarters
            /// Also Rebuilds array after transaction
            Array.Clear(coinageInventory,0,4);
            foreach (Coin coin in coins)
            {
                switch (coin.Value)
                {
                    case 0.25: // Quarter
                        coinageInventory[0]++;
                        break;
                    case 0.10: // Dime
                        coinageInventory[1]++;
                        break;
                    case 0.05: // Nickel
                        coinageInventory[2]++;
                        break;
                    case 0.01: // Penny
                        coinageInventory[3]++;
                        break;
                    default:
                        break;
                }
            }
            return coinageInventory;
        }

    }
}
