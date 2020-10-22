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
        private bool validPayment;

        public int[] HoldTransfer;

        // Ctor
        public Simulation()
        {
            sodaMachine = new SodaMachine(); // SodaMachine Object exists here.
            customer = new Customer(); // Customer object, with it's wallet, coins, card, and backpack exists here.
            SelectMainMenu();
            HoldTransfer = new int[4]; //Transfer Array to pass coins between the customer and the machine
        }
        // Member Methods

        public void SelectMainMenu()
        {
            bool askAgain = true;
            double payAmount = 0.00d;
            int paymentSelection = 0;
            string transferCan;

            do
            {
                UserInterface.Clear();
                UserInterface.DisplayMainMenu();
                int userInput = UserInterface.IntInputValidation("Select a menu option: ");
                switch (userInput)
                {
                    case 1: /* PURCHASE SODA */
                        UserInterface.Clear();
                        payAmount = sodaMachine.UISodaSelection();  // Loads selection UI returns payment value
                        customer.UISelectPaymentType(payAmount);    // Asks for payment type with dynamic payment value
                        validPayment = SelectPayment(payAmount);       // User Selects payment type then asked for payment
                        transferCan = sodaMachine.DispenseSoda(validPayment);
                        customer.backPack.AddSodaToBackPack(transferCan);
                        sodaMachine.UpdateRegisterCoinage();
                        sodaMachine.UpdateSodaInventory();
                        askAgain = true;
                        break;

                    case 2: /* CHECK WALLET FUNDS */
                        UserInterface.Clear();
                        customer.UICheckWallet();
                        askAgain = true;
                        break;

                    case 3: /* CHECK BACKPACK METHOD */
                        askAgain = true;
                        break;

                    case 4: /* CHECK SODA INVENTORY */
                        UserInterface.Clear();
                        sodaMachine.UIMachineInventory();
                        askAgain = true;
                        break;

                    case 5:
                        askAgain = false;
                        break;

                    default: Console.WriteLine("exit"); break;
                }

            } while (askAgain == true);


        }
        public bool SelectPayment(double payAmount)
        {
            int paymentSelection = 0;
            bool askAgain = true;
            do
            {
                paymentSelection = UserInterface.IntInputValidation("Select your payment type: ");
                switch (paymentSelection)
                {
                    case 1: /*WALLET*/
                        ; askAgain = false;
                        if (customer.wallet.CheckCoins(payAmount) == false)  // Check Funds before payment request
                        {
                            Console.WriteLine("Insufficient Funds");
                            askAgain = true;
                        }
                        else
                        {                                           // Select coins and pay
                            customer.wallet.UICoinPayment(payAmount);        // Displays dynamic payment selection
                            customer.wallet.CheckCoins(payAmount);           // User inserts their coins
                            customer.wallet.TransferCoins(payAmount);
                            sodaMachine.MakeTransaction();
                            
                            customer.wallet.UpdateCoinageInventory(true);     // After payment Updates the coins available 
                            askAgain = false;                       // in the customer's possession
                        }
                        break;
                    case 2: /*CARD*/
                        ;
                        if (customer.card.SwipeCard(payAmount) == false)
                        {   // Does not swipe card
                            Console.WriteLine("Insufficient Funds");
                            askAgain = true;
                        }
                        else
                        {   // Cards swipes and payment is deducted

                            customer.paymentMade = true;
                            askAgain = false;
                        }

                        break;
                    case 3: /*Exit*/
                        ; askAgain = false;

                        break;
                    default:
                        Console.WriteLine("Incorrect Payment option");
                        askAgain = true; break;
                }
            } while (askAgain == true);

            return paymentMade;
        }

    }
}
