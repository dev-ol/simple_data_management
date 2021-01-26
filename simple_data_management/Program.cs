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
            Console.WriteLine("Welcome to OL Data Management System.\n");
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

                // conditional statements to select each option
                if (choice.ToLower() == "c")
                {
                    // list is not empty; passing a reference of the list
                    listEmpty = CreateItem(ref items);

                }
                else if (choice.ToLower() == "r" && !listEmpty)
                {
                    //displays the items of the list; 
                    //passing a reference of the list
                    ListItem(ref items);

                }
                else if (choice.ToLower() == "u" && !listEmpty)
                {
                    //updates item in the list
                    //passing a reference of list
                    UpdateItem(ref items);

                }
                else if (choice.ToLower() == "d" && !listEmpty)
                {
                    //deletes an item from the list
                    //passing a reference of list
                    listEmpty = DeleteItem(ref items);
                }
                else if (choice.ToLower() == "q")
                {   
                    //quits the program
                    cont = false;
                }
                else
                {
                    //wrong user input
                    Console.WriteLine("[>>>>Incorrect choice! Try again<<<<]");
                }
            } while (cont == true);

        }

        /*
         * Displays the menu for the user
         */
        static void DisplayMenu(bool listEmpty)
        {
            Console.WriteLine("Choose from the Menu:");
            Console.WriteLine("(Type c) Create an item.");
            
            //if list is empty, these options are not shown
            if (!listEmpty)
            {
                Console.WriteLine("(Type r) List all items.");
                Console.WriteLine("(Type u) Update an item.");
                Console.WriteLine("(Type d) Delete an item.");
            }

            Console.WriteLine("(Type q) Quit :(");

        }
        /*
         * creates an item and adds it to the list
         * takes a reference to a list 
         * returns false because list is no longer emptyu
         */
        static bool CreateItem(ref List<string> itemCache)
        {
            Console.Write("Enter an item >>> ");
            string item = Console.ReadLine();

            itemCache.Add(item);

            Console.WriteLine("[Item Created]\n");
            return false;
        }

        /*
         * displays each item with a basic pagination
         */
        static void ListItem(ref List<string> itemCache)
        {
            int cacheAmount = itemCache.Count();
            int displayCount = 0; //count each item iterated through
            int currentPage = 0; // stores the current page
            // total number of page
            int totalPages = (cacheAmount / 5) + ((cacheAmount % 5 > 0)? 1 : 0) ;

            Console.WriteLine("\nItems : ");
            for (int i = 0; i < cacheAmount; i++)
            {
                if(displayCount == 5)
                {
                    Console.WriteLine($"Page {currentPage+1} 0f {totalPages} ");
                    Console.WriteLine("(Type N/n) Next Page");
                    
                    if ((currentPage + 1) > 1)
                    {
                        Console.WriteLine("(Type P/p) Previous Page");
                    }

                    string cmd = Console.ReadLine();

                    if(cmd.ToLower() == "n")
                    {
                        displayCount = 0;
                        currentPage++;
                    }else if (cmd.ToLower() == "p" && (currentPage + 1) > 1)
                    {
                        i = i - 10;
                        displayCount = 0;
                        currentPage--;
                    }
                    
                }

                Console.WriteLine((i + 1) + ") " + itemCache[i]);
                displayCount++;
               
            }

            Console.WriteLine($"Page {currentPage+1} 0f {totalPages} \n");
        }

        /*
         * Updates a single item
         * takes a reference to a list
         */
        static void UpdateItem(ref List<string> itemCache)
        {
            int index = 0;

            Console.WriteLine("What item number you want to update >>>>");

            /*
             * parsing the string into a int and if fail and checks
             * if the index is too large the user will get an error message 
             * Or if an int wasn't entered
             */
            if (!Int32.TryParse(Console.ReadLine(), out index) || index > itemCache.Count())
            {
                Console.WriteLine("[>>>>Incorrect Item Number<<<<]\n");

                return;
            }

            Console.WriteLine("Do you want to update item (" + (index) + ") " + itemCache[index - 1]
                + "\n(Type Yes/no)");

            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("New Item >>>>");
                string update = Console.ReadLine();

                itemCache[index - 1] = update; //updates item

                Console.WriteLine("[Updated]\n");
            }

        }

        /*
        * Deletes a single item
        * takes a reference to a list
        */
        static bool DeleteItem(ref List<string> itemCache)
        {
            int index = 0;
            Console.WriteLine("What item number you want to delete >>>>");

            /*
            * parsing the string into a int and if fail and checks
            * if the index is too large the user will get an error message 
            * Or if an int wasn't entered
            */
            if (!Int32.TryParse(Console.ReadLine(), out index) || index > itemCache.Count())
            {
                Console.WriteLine("[>>>>Incorrect Item Number<<<<]\n");
            }
            else
            {
                Console.WriteLine("Do you want to Delete item (" + (index) + ") " + itemCache[index - 1]
                    + "\n(Type Yes/no)");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    itemCache.RemoveAt(index - 1); // deletes item
                    Console.WriteLine("[Deleted]\n");
                }
            }
            return itemCache.Count() == 0;
        }
    }
}
