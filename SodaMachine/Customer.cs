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
        public Card card;

        public bool paymentMade;
        public int[] coinsInHand;

        // Ctor
        public Customer()
        {
            wallet = new Wallet();
            backPack = new BackPack();
            card = new Card();
        }

        /////////////// UI AND PAYMENT HANDLING ///////////////

        public void UICheckWallet()
        {
            string displayValue = "";
            UserInterface.MenuDecorators("starlong");

            Console.WriteLine("#### WHAT'S IN MY WALLET? ####");

            UserInterface.MenuDecorators("starlong");
            Console.WriteLine($"Quarters: {wallet.CoinageInventory[0]}");
            Console.WriteLine($"Dimes: {wallet.CoinageInventory[1]}");
            Console.WriteLine($"Nickels: {wallet.CoinageInventory[2]}");
            Console.WriteLine($"Pennies: {wallet.CoinageInventory[3]}");
            UserInterface.MenuDecorators("starlong");

            displayValue = Math.Round(wallet.TotalAvaliableCoinage, 3).ToString("0.00");
            Console.WriteLine($"Wallet Coins Total: ${displayValue}");

            UserInterface.MenuDecorators("starlong");

            displayValue = Math.Round(card.AvailableFunds, 3).ToString("0.00");
            Console.WriteLine($"${displayValue} on card");   // tells the user how much is in their debt account
            UserInterface.WaitForKey("Press ENTER to continue...", 500);
        }
        
        public void UISelectPaymentType(double payment)
        {
            string displayPayment = Math.Round(payment, 3).ToString("0.00");
            string displayCoin = Math.Round(wallet.TotalAvaliableCoinage, 3).ToString("0.00");
            string displayCard = Math.Round(card.AvailableFunds, 3).ToString("0.00");
            UserInterface.Clear();
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine("     #### Select your Payment ####");
            Console.WriteLine($"        | Soda costs: ${displayPayment} |");
            UserInterface.MenuDecorators("starlong");
            Console.WriteLine($"Pay with: [1] Coins: ${displayCoin} in your wallet \n" +
                              $"          [2] Card: ${displayCard} on your card\n" +
                              $"          [3] Cancel\n");
            UserInterface.MenuDecorators("starlong");
        }

        public double AskForPayment(double payment, Wallet wallet)
        {
            
            
            do
            {

            } while (true);

            return payment;
        }

        
    }
}
