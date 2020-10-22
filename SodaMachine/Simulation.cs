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
            bool askAgain = true;
            double payAmount = 0.00d;
            int paymentSelection = 0;


            do
            {
                UserInterface.Clear();
                UserInterface.DisplayMainMenu();
                int userInput = UserInterface.IntInputValidation("Select a menu option: ");
                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("[1] Beverage Selection");
                        UserInterface.Clear();
                        payAmount = sodaMachine.UISodaSelection();
                        customer.UISelectPaymentType(payAmount);
                        customer.PaymentSelection();

                        askAgain = true;
                        break;

                    case 2:
                        Console.WriteLine("[2] Check Wallet");
                        UserInterface.Clear();
                        customer.UICheckWallet();
                        askAgain = true;
                        break;

                    case 3: /*CHECK BACKPACK METHOD*/
                        Console.WriteLine("Check Backpack 3");
                        askAgain = true;
                        break;

                    case 4:
                        UserInterface.Clear();
                        sodaMachine.CheckSodaInventory();
                        Console.WriteLine("Check Soda Inventory 4");
                        askAgain = true;
                        break;

                    case 5:
                        
                        askAgain = false;
                        break;

                    default: Console.WriteLine("exit"); break;
                }

            } while (askAgain == true);
            

        }



    }
}
