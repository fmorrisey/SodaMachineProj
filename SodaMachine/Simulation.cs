using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// this class will instantiate the SodaMachine and Customer Objs
    /// </summary>
    class Simulation
    {
        // Member Variables
        public SodaMachine sodaMachine;
        public Customer customer;
        // Ctor
        public Simulation()
        {
            sodaMachine = new SodaMachine(); // SodaMachine Object exists here.
            customer = new Customer(); // Customer object, with it's wallet, coins, card, and backpack exists here.
            SelectMainMenu();

        }
        // Member Methods

        public void SelectMainMenu()
        {
            UserInterface.DisplayMainMenu();
            int userInput = UserInterface.IntInputValidation();

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("[1] Beverage Selection");
                    UserInterface.DisplaySodaSelction();
                    sodaMachine.SodaSelection();
                    break;

                case 2:
                    Console.WriteLine("[2] Check Wallet");
                    customer.wallet.CheckWallet();
                    break;

                case 3: /*CHECK BACKPACK METHOD*/
                    Console.WriteLine("Check Backpack 3");
                    break;

                case 4: sodaMachine.CheckSodaInventory();
                    Console.WriteLine("Check Soda Inventory 4");
                    break;

                case 5:
                    UserInterface.ExitMessageDraw();
                    break;

                default: Console.WriteLine("exit"); break;
            }
        }



    }
}
