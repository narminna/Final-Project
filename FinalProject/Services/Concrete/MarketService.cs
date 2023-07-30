using Final_Project.Data.Enums;
using Final_Project.Data.Models;
using Final_Project.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project.Services.Concrete
{
    public class MarketService : IMarketable
    {

        private List<Product> products;
        private List<Sales> sales;
        private List<SaleItem> saleItems;
        private List<Category> categories;
        public MarketService()
        {
            products = new List<Product>();
            sales = new List<Sales>();
            saleItems = new List<SaleItem>();
            categories = new List<Category>();
        }        
        public List<Category> GetCategories()
        {
            return categories;
        }
        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Sales> GetSales()
        {
            return sales;
        }

        public List<SaleItem> GetSaleItems()
        {
            return saleItems;
        }

        public int AddProduct(string name, decimal price, Category category, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");

            if (price < 0) throw new Exception("Price can't be less than 0!");

            if (quantity < 0) throw new Exception("Quantity can't be less than 0!");

            var product = new Product(name, price, category, quantity);
            products.Add(product);
            return product.ID;
        }

        public void UpdateProduct(int id, string name, decimal price, Category category, int quantity)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name can't be empty!");

            if (price < 0) throw new Exception("Price can't be less than 0!");

            if (quantity < 0) throw new Exception("Quantity can't be less than 0!");

            var product = products.FirstOrDefault(p => p.ID == id);

            if (product == null) throw new Exception("Product not found!");

            product.Name = name;
            product.Price = price;
            product.Category = category;
            product.Quantity = quantity;
        }

        public void RemoveProduct(int id)
        {
            if (id < 0) throw new Exception("ID can't be less than 0!");

            int productIndex = products.FindIndex(p => p.ID == id);
             
            if (productIndex == -1) throw new Exception("Product not found!");

            products.RemoveAt(productIndex);
        }
        public List<Product> SearchProductByName(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty");
            var foundProducts = products.Where(x=>x.Name.ToLower().Trim()==name.ToLower().Trim()).ToList();

            return foundProducts;
        }

        public List<Product> ShowProductByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) throw new Exception("Min Price can't be higher than max Price");
            return products.Where(x=>x.Price >= minPrice && x.Price<=maxPrice).ToList();
        }

        public List<Product> ShowProductFromCategory(Category category)
        {
            var productsFromCategory = products.Where(p => p.Category == category).ToList();
            return productsFromCategory;
        }


        /*public int AddSale(int saleItemQuantity, int productId, DateTime date)
        {
            if (saleItemQuantity <= 0) throw new Exception("Quantity should be greater than 0!");

            var product = products.FirstOrDefault(p => p.ID == productId);
            if (product == null) throw new Exception("Product not found!");

            var saleItemsToAdd = new List<SaleItem>();

            for (int i = 0; i < saleItemQuantity; i++)
            {
                saleItemsToAdd.Add(new SaleItem(product, 1));
            }

            decimal totalAmount = saleItemsToAdd.Sum(saleItem => saleItem.Product.Price);

            var sale = new Sales(totalAmount, saleItemsToAdd, date);
            sales.Add(sale);

            return sale.ID;*/

        public int AddSale(int productId, int quantity, DateTime date)
        {
            List<SaleItem> saleItems = new List<SaleItem>();

            var product = products.Find(x => x.ID == productId);

            if (quantity <= 0) throw new Exception("Quantity can't be less than 0 or equal to 0!");
            if (product == null) throw new Exception("Product not found.");
            if (product.Quantity < quantity) throw new Exception("Not enough product in stock.");
            else
            {
                var price = product.Price * quantity;
                product.Quantity -= quantity;

                var saleItem = new SaleItem(product, quantity);
                saleItems.Add(saleItem);

                Console.WriteLine("Product was successfully added!");
            }
            int option;
            do
            {
                Console.WriteLine("Do you want to add more sale item?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                while(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");
                }

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Add product's ID:");
                        int productID = int.Parse(Console.ReadLine());

                        Console.WriteLine("Add product's quantity:");
                        int productQuantity = int.Parse(Console.ReadLine());

                        var Product = products.Find(x=>x.ID == productID);
                        var amount = Product.Price * productQuantity;
                        Product.Quantity -= productQuantity;

                        var SaleItem = new SaleItem(Product, productQuantity);
                        break; 
                    case 2:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }
            } while (option!=0);
            return sales.Last().ID;
        }
        public void RemoveSales(int id)
        {
            if (id < 0) throw new Exception("ID can't be less than 0!");

            int saleIndex = sales.FindIndex(p => p.ID == id);

            if (saleIndex == -1) throw new Exception("Sale not found!");

            products.RemoveAt(saleIndex);
        }
        public List<Sales> ShowSaleByID(int id)
        {
            if (id < 0) throw new Exception("ID can't be less than 0!");

            var salesList = sales.Where(sale => sale.ID == id).ToList();

            if (salesList.Count == 0)
            {
                Console.WriteLine($"No sale found with the given ID: {id}");
            }

            return salesList;

        }

        public List<Sales> ShowSaleByPriceRange(decimal minAmount, decimal maxAmount)
        {
            if (minAmount > maxAmount) throw new Exception("Min Price can't be higher than max Price");
            return sales.Where(x => x.Amount >= minAmount && x.Amount <= maxAmount).ToList();
        }

        public List<Sales> ShowSalesByDateRange(DateTime fromDate, DateTime dueDate)
        {
            if (fromDate > dueDate) throw new Exception("From Date can't be after due Date!");
            return sales.Where(x => x.DateTime >= fromDate && x.DateTime <= dueDate).ToList();
        }

        public List<Sales> ShowSalesByExactDate(DateTime datetime)
        {
            throw new NotImplementedException();
        }
    }
}
