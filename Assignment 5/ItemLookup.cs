using System;
using static System.Console;
namespace Assignment_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The following parallel arrays are in an order where
            // the "items" array acts as the primary key to the string in the "descriptions" array
            // and the prices in the "prices" array
            int[] items = { 45, 70, 94, 20, 19, 50, 38, 46 };
            string[] descriptions = { "Book", "Keyboard", "Earbuds", "Mouse", "Video Game", "Bag of Coffee", "Fancy Mug", "Pie"};
            double[] prices = { 21.17, 47.29, 27.29, 26.46, 47.80, 7.82, 44.52, 3.14 };
            // the following boolean variable is used to get an output in the do loop
            bool userInputBool = false;
            // the following variables (userInputString and userInput) are declared here
            // so that they are not declared every iteration of the do loop
            string userInputString;
            int userInput;

            WriteLine("Enter the item number you wish to look up");
            WriteLine("Type \"999\" to end the program");

            do
            {
                Write("Enter the item number >> ");
                userInputString = ReadLine();
                // the following line is for input validation, in case the user inputs something
                // other than an integer
                // it does this by parsing userInputString to the int data type
                // if there is an error, it goes to the else statement at the end of the do loop
                // if there is no error, it assigned the value to the userInput variable
                if (int.TryParse(userInputString, out userInput))
                {
                    for (int x = 0; x < items.Length; ++x) 
                    {
                        if (userInput == items[x])
                        {
                            WriteLine("The price for {0} is {1}", descriptions[x], prices[x].ToString("C"));
                            userInputBool = true;
                            break;
                        }
                    }
                    if (userInputBool == false)
                    {
                        WriteLine("Item not found!");
                    }
                }
                else if (userInput == 999) // used to exit the program
                    break;
                else
                    WriteLine("Invalid input!");
            } while (userInput != 999);

        }
    }
}
