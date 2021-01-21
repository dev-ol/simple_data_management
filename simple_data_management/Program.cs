using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_data_management
{
    class Program
    {
        static void Main(string[] args)
        {
            //list of string to manage the item added by users
            List<string> items = new List<string>();
            bool cont = true;
            Console.WriteLine("Welcome to OL Data Management System.");
            string choice = "m";

            bool listEmpty = true;
            do
            {
                
                if (cont)
                {
                    DisplayMenu(listEmpty);
                    Console.Write(">>>> ");
                    choice = Console.ReadLine();
                }

                if (choice.ToLower() == "c")
                {
                    listEmpty = CreateItem(ref items);
                    
                } else if (choice.ToLower() == "r" && !listEmpty)
                {
                    ListItem(ref items);
                    
                }
                else if (choice.ToLower() == "u" && !listEmpty)
                {
                    UpdateItem(ref items);
                    
                }
                else if (choice.ToLower() == "d" && !listEmpty)
                {
                   listEmpty= DeleteItem(ref items);
                   
                }
                
                else if (choice.ToLower() == "q")
                {
                    cont = false;
                }
                else
                {
                    Console.WriteLine("Incorrect choice! Try again");
                }

                
                
            } while (cont == true);
            
        }

        static void DisplayMenu(bool listEmpty)
        {
            Console.WriteLine("Choose from the Menu:");
            Console.WriteLine("(Type c) Create an item.");
            if (!listEmpty)
            {
                Console.WriteLine("(Type r) List all items.");
                Console.WriteLine("(Type u) Update an item.");
                Console.WriteLine("(Type d) Delete an item.");
            }
           
            Console.WriteLine("(Type q) Quit :(");

        }

        static bool CreateItem(ref List<string> itemCache)
        {
            Console.Write("Enter an item >>> ");
            string item = Console.ReadLine();

            itemCache.Add(item);
            return false;
        }

        static void ListItem(ref List<string> itemCache)
        {

        }

        static void UpdateItem(ref List<string> itemCache)
        {

        }
        static bool DeleteItem(ref List<string> itemCache)
        {
            return itemCache.Count() == 0;
        }
    }
}
