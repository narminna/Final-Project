using Final_Project.Services.Concrete;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Helper
{
    public class SubMenu
    {
        public static void ProductSubMenu()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add product.");
                Console.WriteLine("2. Update product.");
                Console.WriteLine("3. Remove product.");
                Console.WriteLine("4. Show all products.");
                Console.WriteLine("5. Show all products by category.");
                Console.WriteLine("6. Show all products by price range.");
                Console.WriteLine("7. Search products by name.");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                Console.WriteLine("0. Go back");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                }

                switch (option)
                {
                    case 1:
                        MenuServices.MenuAddProduct();
                        break;
                    case 2:
                        MenuServices.MenuUpdatePorduct();
                        break;
                    case 3:
                        MenuServices.MenuRemoveProduct();
                        break;
                    case 4:
                        MenuServices.MenuShowAllProduct();
                        break;
                    case 5:
                        MenuServices.MenuChooseProductCategory();
                        break;
                    case 6:
                        MenuServices.MenuPriceRangeProduct();
                        break;
                    case 7:
                        MenuServices.MenuSearchProductByName();
                        break;
                    case 0:
                        MenuServices.MenuGoBack();
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option != 0);
        }

        public static void SalesSubmenu()
        {
            Console.Clear();

            int option;

            do
            {
                Console.WriteLine("1. Add new sale.");
                Console.WriteLine("2. Return sales.");
                Console.WriteLine("3. Remove sale.");
                Console.WriteLine("4. Show all sales.");
                Console.WriteLine("5. Show sales by date range.");
                Console.WriteLine("6. Show sales by price range.");
                Console.WriteLine("7. Show sale by given date.");
                Console.WriteLine("8. Show sales by given ID.");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                Console.WriteLine("0. Go back");
                Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");

                while(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~");
                }
                switch (option)
                {
                    case 1:
                        MenuServices.MenuAddSales();
                        break;
                    case 2:
                        MenuServices.MenuReturnSales();
                        break;
                    case 3:
                        MenuServices.MenuRemoveSales();
                        break;
                    case 4:
                        MenuServices.MenuShowAllSales();
                        break;
                    case 5:
                        MenuServices.MenuShowSalesByDate();
                        break;
                    case 6:
                        MenuServices.MenuShowSalesByPrice();
                        break;
                    case 7:
                        MenuServices.MenuShowSalesByGivenDate();
                        break;
                    case 8:
                        MenuServices.MenuShowSalesByGivenID();
                        break;
                    case 0:
                        Console.WriteLine("Bye!");
                        MenuServices.MenuGoBack();
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option!=0);
        }
    }
}
