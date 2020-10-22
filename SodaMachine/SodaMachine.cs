using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// This class will hold the Register and Inventory Lists collections
    /// Fills the lists with objects for the collection
    /// </summary>
    class SodaMachine
    {
        // Member Variables
        public List<Coin> register;
        public List<Can> inventory;

        private int[] avalibleInventory;
        private double stockTotalValue;
        private bool isMachineEmpty;

        // Properties
        public int[] AvalibleInventory
        {
            get { return avalibleInventory; }
        }
        public double StockTotalValue
        {
            get { return stockTotalValue; }
        }

        // Ctor
        public SodaMachine()
        {
            register = new List<Coin>();    // coin object collection
            FillRegister(20, 10, 20, 50);   // fill the register with coins

            inventory = new List<Can>();    // can object collection
            FillSodaMachine(20, 20, 20);    // fills the soda machine inventory
            
            this.avalibleInventory = TotalSodaInventory();
            this.stockTotalValue = TotalInventoryCost();


        }

        /////////////// Selection Methods ///////////////

        public bool IsMachineEmpty()
        {
            if (inventory.Count == 0)
            {
                isMachineEmpty = true;
            }
            else
            {
                isMachineEmpty = false;
            }

            return isMachineEmpty;
        }

        public void SodaSelection()
        {
            int sodaSelection;
            sodaSelection = UserInterface.IntInputValidation();
        }

        public void CheckSodaInventory()
        {
            UserInterface.MenuDecorators("star");
            Console.WriteLine($"Root Beer: {AvalibleInventory[0]} \n" +
                                $"Orange Soda: {AvalibleInventory[1]} \n" +
                                $"Cola: {AvalibleInventory[2]}");
            UserInterface.MenuDecorators("star");
            Console.WriteLine($"Total Inventory is: ${StockTotalValue}");
            UserInterface.WaitForKey("Press ENTER to return to menu...", 500);
        }

        /////////////// MEMBER METHODS ///////////////

        private int[] TotalSodaInventory()
        {
            avalibleInventory = new int[3];
            
            foreach (Can can in inventory)
            {
                switch (can.Name)
                {
                    case "Root Beer":
                        avalibleInventory[0]++;
                        break;
                    case "Orange Soda":
                        avalibleInventory[1]++;
                        break;
                    case "Cola":
                        avalibleInventory[2]++;
                        break;
                    default:
                        break;
                }
            }
            
            return avalibleInventory;
        }

        private double TotalInventoryCost()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                stockTotalValue += inventory[i].Cost;
            }
            stockTotalValue = Math.Round(stockTotalValue, 2); 
            return stockTotalValue;
        }

        public void IsPowerOn(bool isPowerOn)                                       //Powers on the soda machine (has no real functionality)
        {
            if (isPowerOn == true) { Console.WriteLine("The Soda Machine is ON"); Thread.Sleep(1000); }
            else { Console.WriteLine("The Soda Machine is OFF"); Thread.Sleep(1000); }
            //return isPowerOn;
        }

        private void FillSodaMachine(int orangesoda, int rootBeer, int cola)         // Adds Sodas to the inventory
        {
            for (int i = 0; i < orangesoda; i++) { inventory.Add(new OrangeSoda()); }
            for (int i = 0; i < rootBeer; i++) { inventory.Add(new RootBeer()); }
            for (int i = 0; i < cola; i++) { inventory.Add(new Cola()); }
            isMachineEmpty = false;
        }

        private void FillRegister(int quarters, int dimes, int nickles, int pennies) // Adds coins to the register
        {
            for (int i = 0; i < quarters; i++) { register.Add(new Quarter()); }
            for (int i = 0; i < dimes; i++) { register.Add(new Dime()); }
            for (int i = 0; i < nickles; i++) { register.Add(new Nickle()); }
            for (int i = 0; i < pennies; i++) { register.Add(new Penny()); }
        }

        public double RegisterReconciliation()
        {
            double registerTotal = 0.0;

            for (int i = 0; i < register.Count; i++)
            {
                registerTotal += register[i].Value;
            }
            registerTotal = Math.Round(registerTotal, 3);

            Console.WriteLine($"Register Total:${registerTotal}");
            Thread.Sleep(2000);
            return registerTotal;
        }

        public void PrintInventoryAndRegister()
        {
            Console.WriteLine("Inventory");
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{inventory[i].Name} at ${inventory[i].Cost}");
            }

            Console.WriteLine("Register");
            for (int i = 0; i < register.Count; i++)
            {
                Console.WriteLine($"{register[i].Name} is ${register[i].Value}");
            }
            Console.ReadLine();
        }

        
    }
}
