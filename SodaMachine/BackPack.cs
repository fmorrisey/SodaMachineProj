using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// The Customer's backpack will hold the soda
    /// </summary>
    class BackPack
    {
        // Member Variables
        public List<Can> cans;

        // Ctor
        public BackPack()
        {
            cans = new List<Can>(); //customer's soda in the backpack
        }

        // Member Methods

        public void AddSodaToBackPack(string canSelection)
        {
            switch (canSelection)
            {
                case "Root Beer": cans.Add(new RootBeer()); break;
                case "Orange Soda": cans.Add(new OrangeSoda()); break;
                case "Cola": cans.Add(new Cola()); break;
                default: Console.WriteLine("BACKPACK: Soda does not exist in this universe"); break;
            }
        }

        public void UIDisplayBackPack()
        {
            UserInterface.Clear();
            if (cans.Count == 0)
            {
                Console.WriteLine("You gotta buy some soda bud!");
            }
            else
            {
                Console.WriteLine("You have: ");
                UserInterface.MenuDecorators("star");
                foreach (Can can in cans)
                {
                    Console.WriteLine($"{can.Name}");
                }
                UserInterface.MenuDecorators("star");
            }
            
            
            UserInterface.WaitForKey("Return to main menu", 1000);
        }

    }
}
