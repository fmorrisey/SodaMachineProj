﻿using System;
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

        // Ctor
        public Customer()
        {
            wallet = new Wallet();
            backPack = new BackPack();
            card = new Card();
        }

        // Member Methods
        /// HERE WE ADD METHODS THAT WILL
        /// Insert money into the machine

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

        public void PaymentSelection()
        {
            int paymentSelection = 0;
            bool askAgain = true;
            do
            {
                paymentSelection = UserInterface.IntInputValidation("Select your payment type: ");
                switch (paymentSelection)
                {
                    case 1: /*WALLET*/; askAgain = false; break;
                    case 2: /*CARD*/; askAgain = false;  break;
                    case 3: /*Exit*/; askAgain = false;  break;
                    default: Console.WriteLine("Incorrect Payment option");
                        askAgain = true; break;
                }
            } while (askAgain == true);

            //return paymentSelection;
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

        /*
        public void AddMoney(double amountToAdd)
        {
            wallet.availableFunds += amountToAdd;
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
