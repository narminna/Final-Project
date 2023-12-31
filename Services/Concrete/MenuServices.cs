﻿using ConsoleTables;
using Final_Project.Data.Enums;
using Final_Project.Data.Models;
using Final_Project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Services.Concrete
{
    public class MenuServices
    {
        private static MarketService marketService = new MarketService();//creates market service instance to get access to methods
        public static void MenuAddProduct() //the user enters the lower written information to create a new product
        {
            try
            {
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                decimal price = decimal.Parse(Console.ReadLine());//takes as string turns to decimal

                Console.WriteLine("Enter the number to choose Product Category: 0. Cereals 1. Vegetables 2. Fruits 3. Meat 4. Dairy 5. Drinks 6. Snacks 7. Frozen 8. Canned Food 9. Cleaning Stuff");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);//converts a numeric value that is of string type into a corresponding Enum

                Console.WriteLine("Enter Product Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                int newId = marketService.AddProduct(name, price, category, quantity);//this information will be called to market service class
                Console.WriteLine($"Froduct {name} with ID: {newId} has been successfully added!");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuUpdateProduct()//with this method can updated before given data
        {

            try
            { 
                Console.WriteLine("Add product ID:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number to choose Product Category: 0. Cereals 1. Vegetables 2. Fruits 3. Meat 4. Dairy 5. Drinks 6. Snacks 7. Frozen 8. Canned Food 9. Cleaning Stuff");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

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

        public static void MenuRemoveProduct()//deletes selected by id product from list
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

                if (products.Count == 0)//checks whether there is a product before then to show it later
                {
                    Console.WriteLine("No products have been found");
                    return;
                }

                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");//collums in table

                foreach (var product in products)//loop that will output in rows data
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

        public static void MenuChooseProductByCategory()//Show products by category
        {
            try
            {
                Console.WriteLine("Choose product category:");

                foreach (Category enumValue in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(enumValue);
                }
                string userInput = Console.ReadLine();
                Category category;

                if (!Enum.TryParse(userInput, true, out category))//Converts the string representation of the name or numeric value 
                {
                    Console.WriteLine($"Invalid category input: {userInput}");
                    return;
                }
                var products = marketService.ShowProductsByCategory(category);

                if (products.Count == 0) throw new Exception($"No products found in the {category} category.");
                else
                {
                    var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");
                    foreach (var product in products)
                    {
                        table.AddRow(product.ID, product.Name, product.Price, product.Category, product.Quantity);
                    }
                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error! {ex.Message}");
            }
        }

        public static void MenuPriceRangeProduct()//gets from the list the product according given price range from user
        {
            try
            {
                Console.WriteLine("Enter product's min price");
                decimal minPrice;
                while (!decimal.TryParse(Console.ReadLine(), out minPrice))
                {
                    Console.WriteLine("Invalid input!");
                }

                Console.WriteLine("Enter product's max price:");
                decimal maxPrice;
                while (!decimal.TryParse(Console.ReadLine(), out maxPrice))
                {
                    Console.WriteLine("Invalid input!");
                }

                var prodRange = marketService.ShowProductsByPriceRange(minPrice, maxPrice);//calls market service method to show product by iven price range
                if (prodRange.Count == 0) throw new Exception("No products found in that range.");
                else
                {
                    var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");
                    foreach (var product in prodRange)
                    {
                        table.AddRow(product.ID, product.Name, product.Price, product.Category, product.Quantity);
                    }
                    table.Write();
                }
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

                var foundProducts = marketService.SearchProductsByName(search);

                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("No Such Product");
                    return;
                }
                var table = new ConsoleTable("ID", "Name", "Price", "Category", "Quantity");
                foreach (var product in foundProducts)
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

        public static void MenuAddSales()//during add sale method, sends which and the number and the date of products
        {
            try
            {
                Console.WriteLine("Enter the number of sale items you want to add:");
                int saleItemQuantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product ID:");
                int productId = int.Parse(Console.ReadLine());

                DateTime datetime = DateTime.Now;

                int saleID = marketService.AddSale(productId, saleItemQuantity, datetime);
                Console.WriteLine($"Sale with ID: {saleID} was successfully created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuReturnSales()//returns the product from sale by id
        {
            try
            {
                Console.WriteLine("Enter the sale ID:");
                int saleId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the product ID to return:");
                int productId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the quantity to return:");
                int quantity = int.Parse(Console.ReadLine());

                marketService.ReturnProductFromSale(saleId, productId, quantity);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuRemoveSales()//removes total sale
        {
            try
            {
                Console.WriteLine("Enter Sale ID:");
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveSale(id);
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
                    table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.SaleItem.ToString());
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByDateRange()//gets from the list the sales according given date range from user
        {
            try
            {
                Console.WriteLine("Enter Sale's date from");
                DateTime fromDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Sale's date due:");
                DateTime dueDate = DateTime.Parse(Console.ReadLine());

                var saleRange = marketService.ShowSalesByDateRange(fromDate, dueDate);
                if (saleRange.Count == 0) throw new Exception("No sales found!");
                else
                {
                    var table = new ConsoleTable("ID", "Amount", "DateTime", "SaleItems");
                    foreach (var sale in saleRange)
                    {
                        table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.ToString()); // Use ToString() here
                    }

                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByPrice()//here gets from the list according one exact date
        {
            try
            {
                Console.WriteLine("Enter Sale's minimum price");
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter Sale's maximum price:");
                decimal maxPrice = decimal.Parse(Console.ReadLine());

                var salesInRange = marketService.ShowSaleByPriceRange(minPrice, maxPrice);

                if (salesInRange.Count == 0) throw new Exception($"No sales found between {minPrice} and {maxPrice}.");
                else
                {
                    var table = new ConsoleTable("ID", "Amount", "DateTime", "SaleItems");

                    foreach (var sale in salesInRange)
                    {
                        table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.ToString());
                    }

                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }


        public static void MenuShowSalesByGivenDate()//gets from the list the sales according given price range from user
        {
            try
            {
                Console.WriteLine("Enter Sale's date");
                DateTime date = DateTime.Parse(Console.ReadLine());

                var foundSales = marketService.ShowSalesByExactDate(date);
                if(foundSales.Count == 0) throw new Exception($"No sales found by that date!");
                
                else 
                {
                    var table = new ConsoleTable("ID", "Amount", "DateTime", "SaleItem");
                    foreach (var sale in foundSales)
                    {
                        table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.ToString());
                    }
                    table.Write();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }

        public static void MenuShowSalesByGivenID()//returns as output according id that user will give
        {
            try
            {
                Console.WriteLine("Enter Sale's ID for search:");
                int id = int.Parse(Console.ReadLine());

                var foundSale = marketService.ShowSaleByID(id);//calls market service method to show sales according ID 

                if (foundSale.Count == 0)
                {
                    Console.WriteLine("No sales found.");
                    return;
                }
                var table = new ConsoleTable("ID", "Amount", "DateTime", "SaleItem");
                foreach (var sale in foundSale)
                {
                    table.AddRow(sale.ID, sale.Amount, sale.DateTime, sale.ToString());
                }
                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"OOPS, got an error!{ex.Message}");
            }
        }
    }
}
