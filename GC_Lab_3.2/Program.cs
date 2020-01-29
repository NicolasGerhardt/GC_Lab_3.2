using System;
using System.Collections;
using System.Collections.Generic;

namespace GC_Lab_3._2
{
    class Program
    {

        const int MENU_AND_CART_PADDING = 6;
        static void Main(string[] args)
        {
            Dictionary<string, double> menuItems = PopulateMenuItems();

            Console.WriteLine("#############################################");
            Console.WriteLine("## Welcome to Nic's Happy Food and Stuff!! ##");
            Console.WriteLine("#############################################");

            PrintMenuItems(menuItems);

            FillCart(menuItems, out ArrayList itemCart, out List<double> itemPriceCart);

            Console.WriteLine();
            Console.WriteLine("Looks like you are all done shopping.");
            Console.WriteLine("Lets take a quick look at what you ordered.");
            PrintCart(itemCart, itemPriceCart);
            double avePrice = GetAvePrice(itemPriceCart);
            Console.WriteLine($"Exellent, your average item price was ${avePrice:N2}.");
            Console.WriteLine("Have a fantastic day!");

        }

        private static double GetAvePrice(List<double> itemPriceCart)
        {
            var total = 0.0;
            if (itemPriceCart.Count == 0)
            {
                return 0.0;
            }
            foreach(var itemPrice in itemPriceCart)
            {

                total += itemPrice;
            }

            return total / itemPriceCart.Count;
        }

        private static void FillCart(Dictionary<string, double> menuItems, 
            out ArrayList itemCart, out List<double> itemPriceCart)
        {
            PrintHelpMenu();
            itemCart = new ArrayList();
            itemPriceCart = new List<double>();
            var done = false;
            do
            {
                Console.WriteLine();
                Console.Write("What item would you like to add to your cart: ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput.Contains("done"))
                {
                    done = true;
                }
                else if (userInput.Contains("menu"))
                {
                    PrintMenuItems(menuItems);
                } 
                else if (userInput.Contains("cart"))
                {
                    PrintCart(itemCart, itemPriceCart);
                }
                else if (userInput.Contains("help"))
                {
                    PrintHelpMenu();
                }
                else if (TryGetMenuItem(userInput, menuItems, out string item, out double price))
                {
                    itemCart.Add(item);
                    itemPriceCart.Add(price);
                    Console.WriteLine($"added {item} to cart for ${price}");
                }
                else
                {
                    Console.WriteLine("Could not find desired item.");
                    // PrintHelpMenu();
                }

            } while (!done);
        }

        private static void PrintCart(ArrayList itemCart, List<double> itemPriceCart)
        {
            if(itemCart.Count != itemPriceCart.Count)
            {
                throw new ArgumentException("ERROR: item cart and item price cart are out of sync");
            }
            Console.WriteLine();
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}------------------------------");
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}--{"Cart Items",15} | {"Price",-8}--");
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}------------------------------");
            for (var i = 0; i < itemCart.Count; i++)
            {
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}--{itemCart[i],15} | ${itemPriceCart[i],-7}--");
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}------------------------------");
            }

            if (itemCart.Count == 0)
            {
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}--      Cart is empty       --");
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}------------------------------");
            }
            Console.WriteLine();
        }

        private static bool TryGetMenuItem(string desiredItem, Dictionary<string, double> menuItems, 
            out string item, out double price)
        {
            item = string.Empty;
            price = 0.0;
            foreach(var menuItem in menuItems)
            {
                if (menuItem.Key.Contains(desiredItem))
                {
                    item = menuItem.Key;
                    price = menuItem.Value;
                    return true;
                }
            }

            return false;
        }

        static void PrintHelpMenu()
        {
            Console.WriteLine();
            Console.WriteLine("When choosing an item off the list type the exact name.");
            Console.WriteLine("To complete your order type \'done\'");
            Console.WriteLine("To see the menu items list again type \'menu\'");
            Console.WriteLine("To see a list of items in your cart type \'cart\'");
            Console.WriteLine("To see the commands type \'help\'");

        }

        static Dictionary<string, double> PopulateMenuItems()
        {
            var menuItems = new Dictionary<string, double>();
            menuItems.Add("apple", 0.99);
            menuItems.Add("banana", 0.59);
            menuItems.Add("cauliflower", 1.59);
            menuItems.Add("dragonfruit", 2.19);
            menuItems.Add("elderberry", 1.79);
            menuItems.Add("figs", 2.09);
            menuItems.Add("grapefruit", 1.99);
            menuItems.Add("honey dew", 3.49);
            return menuItems;
        }

        static void PrintMenuItems(Dictionary<string, double> menuItems)
        {
            Console.WriteLine();
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}==============================");
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}=={"Menu Items",15} | {"Price",-8}==");
            Console.WriteLine($"{"",MENU_AND_CART_PADDING}==============================");
            foreach (KeyValuePair<string, double> menuItem in menuItems)
            {
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}--{menuItem.Key,15} | ${menuItem.Value,-7}--");
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}------------------------------");
            }
            if (menuItems.Count == 0)
            {
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}==      Menu is empty       ==");
                Console.WriteLine($"{"",MENU_AND_CART_PADDING}==============================");
            }
            Console.WriteLine();
        }
    }
}
