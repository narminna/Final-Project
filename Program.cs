using Final_Project.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Program//qst page of of program which then directs to sub classes
    {
        static void Main(string[] args)
        {
            
            int option;

            do
            {
                Console.WriteLine("1. Product operation");
                Console.WriteLine("2. Sales operation");
                Console.WriteLine("3. Exit");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                Console.WriteLine("Please, enter an option, ZEHMET OLMASA!!!!!!!!!:");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");
                }

                switch (option)
                {
                    case 1:
                        SubMenu.ProductSubMenu();
                        break;
                    case 2:
                        SubMenu.SalesSubmenu();
                        break;
                    case 3:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option!=0);
        }
    }
}
