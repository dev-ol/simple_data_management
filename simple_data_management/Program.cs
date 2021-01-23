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

                }
                else if (choice.ToLower() == "r" && !listEmpty)
                {
                    ListItem(ref items);

                }
                else if (choice.ToLower() == "u" && !listEmpty)
                {
                    UpdateItem(ref items);

                }
                else if (choice.ToLower() == "d" && !listEmpty)
                {
                    listEmpty = DeleteItem(ref items);

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
            int cacheAmount = itemCache.Count();
            int lastPage = 0;
            int pageCount = 0;
            int currentPage = 0;
            int number = 0;

            for (int i = 0; i < cacheAmount; i++)
            {
                Console.WriteLine((i + 1) + ") " + itemCache[i]);

                if ((number + 1) == 5)
                {
                    currentPage++;
                    number = 0;
                }
                else
                {
                    number++;
                }

            }

            Console.WriteLine("Pages: " + (currentPage + 1).ToString());
        }

        static void UpdateItem(ref List<string> itemCache)
        {
            int count = itemCache.Count();
            Console.WriteLine("What item number you want to update >>>>");
            int index = 0;
            if (!Int32.TryParse(Console.ReadLine(), out index) || index > count)
            {
                Console.WriteLine("Bad index");
                return;
            }

            Console.WriteLine("Do you want to update item (" + (index) + ") " + itemCache[index - 1]
                + "\n(Type Yes/no)");

            if (Console.ReadLine().ToLower() == "yes")
            {
                Console.WriteLine("New Item >>>>");
                string update = Console.ReadLine();

                itemCache[index - 1] = update;

                Console.WriteLine("[Updated]");
            }

        }
        static bool DeleteItem(ref List<string> itemCache)
        {
            int count = itemCache.Count();
            Console.WriteLine("What item number you want to delete >>>>");
            int index = 0;
            if (!Int32.TryParse(Console.ReadLine(), out index) || index > count)
            {
                Console.WriteLine("Bad index");
            }
            else
            {
                Console.WriteLine("Do you want to Delete item (" + (index) + ") " + itemCache[index - 1]
                    + "\n(Type Yes/no)");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    itemCache.RemoveAt(index - 1);
                    Console.WriteLine("[Deleted]");
                }
            }
            return itemCache.Count() == 0;
        }
    }
}
