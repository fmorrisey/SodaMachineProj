using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    /// <summary>
    /// This class handles logic such as input validation
    /// </summary>
    public static class Logic
    {
        public static int InputValidation(int UserInput)
        {   // Handles Main Menu user input with validation
            bool askAgain;

            do
            {
                Console.Write("Enter a menu option: ");
                if (int.TryParse(Console.ReadLine(), out UserInput))
                { return UserInput; }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            } while (askAgain == true);

            return UserInput;
            
        }

        public static double InputValidation(double UserInput)
        {
            // Handles Main Menu user input with validation
            bool askAgain;

            do
            {
                Console.Write("Enter a menu option: ");
                if (double.TryParse(Console.ReadLine(), out UserInput))
                { return UserInput; }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            } while (askAgain == true);

            return UserInput;

        }

        /* FLAGGED FOR REVIEW
        public static string InputValidation(string UserInput)
        {
            // Handles Main Menu user input with validation
            
            bool askAgain;

            do
            {
                Console.Write("Enter a menu option: ");
                if (string.ToLower(Console.ReadLine(), out UserInput))
                { return UserInput; }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    askAgain = true;
                }
            } while (askAgain == true);

            
            return UserInput;
        }
        */

    }
}
