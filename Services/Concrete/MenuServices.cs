using ConsoleTables;
using Final_Project.Data.Enums;
using Final_Project.Data.Models;
using Final_Project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Services.Concrete
{
    public class MenuServices
    {
        private static MarketService marketService = new MarketService();
        public static void MenuAddProduct()
        {
			try
			{
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Category");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                Console.WriteLine("Enter Product Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                int newId=marketService.AddProduct(name, price, category, quantity);
                Console.WriteLine($"Froduct {name} with ID: {newId} has been successfully added!");

            }
			catch (Exception ex)
			{
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuUpdatePorduct()
        {

            try
            {
                Console.WriteLine("Add product ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product name:");
                string name=Console.ReadLine();

                Console.WriteLine("Enter price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Product Category:");
                Category category = (Category)Enum.Parse(typeof (Category), Console.ReadLine(),true);

                Console.WriteLine("Enter Porduct Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                marketService.UpdateProduct(id, name, price, category, quantity);

                Console.WriteLine("Product successfully updated.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuRemoveProduct()
        {

            try
            {
                Console.WriteLine("Enter Product ID:");
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveProduct(id);
                Console.WriteLine("Product has been successfully deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowAllProducts()
        {

            try
            {
                var products = marketService.GetProducts();

                if (products.Count == 0)
                {
                    Console.WriteLine("No products have been found");
                    return;
                }

                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");

                foreach (var product in products)
                {
                    table.AddRow(product.ID, product.Name, product.Price, product.Category, product.Quantity);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuChooseProductByCategory()
        {

            try
            {
                var categories = marketService.GetProducts();

                Console.WriteLine("Choose product category:");
                
                foreach (Category enumValue in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(enumValue);                    
                }
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                foreach(var products in categories)
                {
                    Console.WriteLine($"Id: {products.ID} | Name: {products.Name} | Price: {products.Price} | Category: {products.Category} | Quantity: {products.Quantity}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuPriceRangeProduct()
        {
            try
            {
                Console.WriteLine("Enter product's minimum price");
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter product's maximum price:");
                decimal maxPrice= decimal.Parse(Console.ReadLine());

                marketService.ShowProductByPriceRange(minPrice, maxPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuSearchProductByName()
        {

            try
            {
                Console.WriteLine("Enter product name:");
                string search = Console.ReadLine();

                var foundProducts = marketService.SearchProductByName(search);

                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("No Such Product");
                    return;
                }
                foreach(var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.ID} | Name: {product.Name} | Price: {product.Price} | Category: {product.Category} | Quantity: {product.Quantity}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuAddSales()
        {
            try 
            {
                Console.WriteLine("Enter the number of sale items you want to add:");
                int saleItemQuantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product ID:");
                int productId = int.Parse(Console.ReadLine());

                DateTime datetime = DateTime.Now;

                int saleID = marketService.AddSale(saleItemQuantity, productId, datetime);
                Console.WriteLine($"Sale with ID:{saleID} was successfully created.");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuReturnSales()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuRemoveSales()
        {
            try
            {
                Console.WriteLine("Enter Sale ID:");
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveSales(id);
                Console.WriteLine("Product has been successfully deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowAllSales()
        {
            try
            {
                var sales = marketService.GetSales();

                if (sales.Count == 0)
                {
                    Console.WriteLine("No sales have been found");
                    return;
                }

                var table = new ConsoleTable("ID", "Amount", "DateTime", "SaleItem");

                foreach (var sale in sales)
                {
                    table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.SaleItem);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByDateRange()
        {
            try
            {
                Console.WriteLine("Enter Sale's date from");
                DateTime fromDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Sale's date due:");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                marketService.ShowSalesByDateRange(fromDate, dueDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByPrice()
        {
            try
            {
                Console.WriteLine("Enter Sale's minimum price");
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Sale's maximum price:");
                decimal maxPrice = decimal.Parse(Console.ReadLine());

                marketService.ShowSaleByPriceRange(minPrice, maxPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByGivenDate()
        {
            try
            {
                Console.WriteLine("Enter Sale's date");
                DateTime date = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByGivenID()
        {
            try
            {
                Console.WriteLine("Enter Sale's ID for search:");
                int id = int.Parse(Console.ReadLine());

                var foundSale = marketService.ShowSaleByID(id);

                if (foundSale.Count == 0)
                {
                    Console.WriteLine("No sales found.");
                    return;
                }

                foreach (var sale in foundSale)
                {
                    Console.WriteLine($"Id: {sale.ID} | Amount: {sale.Amount} | SalesItems: {sale.Items} | Date: {sale.Date}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }
    }
}
