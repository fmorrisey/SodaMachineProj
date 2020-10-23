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

        public List<Coin> handsTransfer;

        public int[] HoldTransfer;

        // Ctor
        public Simulation()
        {
            sodaMachine = new SodaMachine(); // SodaMachine Object exists here.
            customer = new Customer(); // Customer object, with it's wallet, coins, card, and backpack exists here.
            handsTransfer = new List<Coin>();
            HoldTransfer = new int[4]; //Transfer Array to pass coins between the customer and the machine
        }
        // Member Methods

        
        public void SelectMainMenu()
        {
            bool askAgain = true;
            double payAmount = 0.00d;
            int paymentSelection = 0;
            string transferCan;
            bool checkMachineREG;

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
                        
                        validPayment = SelectPayment(payAmount);    // User Selects payment type then asked for payment
                            
                        if (validPayment == true)
                        {
                            transferCan = sodaMachine.DispenseSoda(validPayment); // Authorizes can dispensing
                            customer.backPack.AddSodaToBackPack(transferCan);     // Soda is added to the bag
                            sodaMachine.UpdateRegisterCoinage();      // Updates the SodaMachine
                            sodaMachine.UpdateSodaInventory();
                            customer.wallet.UpdateCoinageInventory(); // After payment Updates the coins available 
                        }
                            
                        
                        break;

                    case 2: /* CHECK WALLET FUNDS */
                        UserInterface.Clear();
                        customer.UICheckWallet();
                        askAgain = true;
                        break;

                    case 3: /* CHECK BACKPACK METHOD */
                        customer.backPack.UIDisplayBackPack();
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
        
        public bool SelectPayment(double AmountDue)
        {
            int paymentSelection = 0;
            bool askAgain = true;
            bool checkChange = false;
            bool shortChange = false;
            bool checkMachineREG;

            do
            {
                customer.UISelectPaymentType(AmountDue);
                paymentSelection = UserInterface.IntInputValidation("Select your payment type: ");
                switch (paymentSelection)
                {
                    
                    case 1: /*WALLET*/
                        checkMachineREG = sodaMachine.CheckRegister(AmountDue);
                        if (checkMachineREG == true)
                        {
                            if (customer.wallet.CheckCoins(AmountDue) == false)  // Check Funds before payment request
                            {
                                Console.WriteLine("Insufficient Funds");
                                askAgain = true;
                            }
                            else
                            {                                           // Select coins and pay
                                checkChange = customer.wallet.CheckCoins(AmountDue);           // User inserts their coins
                                if (checkChange == true)
                                {
                                    customer.wallet.UICoinPayment(AmountDue);        // Displays dynamic payment selection
                                    handsTransfer = customer.wallet.TransferCoins(AmountDue);
                                    shortChange = ShortChange(AmountDue);
                                    if (shortChange == false)
                                    {
                                        customer.wallet.WalletContains(handsTransfer);
                                        handsTransfer = sodaMachine.MakeTransaction(handsTransfer);
                                        customer.paymentMade = true;
                                        customer.wallet.ChangeReturn(handsTransfer);
                                        askAgain = false;
                                    }
                                    else
                                    {
                                        UserInterface.Pause("Not Enough Change", 800);
                                        askAgain = true;
                                    }
                                }
                                else { askAgain = true; }
                            }
                            
                        }
                        else
                        {
                            UserInterface.Pause("Machine Has Insufficient Change", 800);
                            askAgain = true;
                        }
                        break;

                    case 2: /*CARD*/
                        
                        if (customer.card.SwipeCard(AmountDue) == false)
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

                    case 3: askAgain = false; break;

                    default:
                        Console.WriteLine("Incorrect Payment option");
                        askAgain = true; break;
                }
            } while (askAgain == true);

            return customer.paymentMade;
        }

        public bool ShortChange(double amountDue)
        {
            double paymentAmount = paymentAmountCheck();

            if (amountDue <= paymentAmount)
            {
                return false;
            }
            else
            {
                return true;
            }

            return true;

        }

        public double paymentAmountCheck()
        {
            double CoinsTotal = 0.0;

            for (int i = 0; i < handsTransfer.Count; i++)
            {
                CoinsTotal += handsTransfer[i].Value;
            }
            CoinsTotal = Math.Round(CoinsTotal, 2);
            return CoinsTotal;
        }

    }
}
