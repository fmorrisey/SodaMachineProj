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

        public bool PaymentSelection(double payAmount)
        {
            int paymentSelection = 0;
            bool askAgain = true;
            do
            {
                paymentSelection = UserInterface.IntInputValidation("Select your payment type: ");
                switch (paymentSelection)
                {
                    case 1: /*WALLET*/; askAgain = false;
                        if (wallet.CheckCoins(payAmount) == false)  // Check Funds before payment request
                        {
                            Console.WriteLine("Insufficient Funds");
                            askAgain = true;
                        }
                        else
                        {                                           // Select coins and pay
                            wallet.UICoinPayment(payAmount);        // Displays dynamic payment selection
                            wallet.CheckCoins(payAmount);           // User inserts their coins
                            wallet.UpdateCoinageInventory();        // After payment Updates the coins available 
                            askAgain = false;                       // in the customer's possession
                        }
                        break;
                    case 2: /*CARD*/;
                        if (card.SwipeCard(payAmount) == false)
                        {   // Does not swipe card
                            Console.WriteLine("Insufficient Funds");
                            askAgain = true;
                        }
                        else
                        {   // Cards swipes and payment is deducted
                            // Now we dispense soda! but how :(
                            paymentMade = true;
                            askAgain = false;
                        }
                        
                        break;
                    case 3: /*Exit*/; askAgain = false;  
                        
                        break;
                    default: Console.WriteLine("Incorrect Payment option");
                        askAgain = true; break;
                }
            } while (askAgain == true);

            return paymentMade;
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

        public double AskForPayment(double payment)
        {


            return payment;
        }

        
    }
}
