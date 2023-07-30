using Final_Project.Data.Enums;
using Final_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Services.Abstract
{
    public interface IMarketable
    {
        List<Product> GetProducts();
        int AddProduct(int id, string name, decimal price, Category category, int quantity);
        void RemoveProduct(int id);
        string UpdateProduct(int id, string name, decimal price, Category category, int quantity);
        List<Product> ShowProductFromCategory(Category category);
        List<Product> ShowProductByPriceRange(decimal minPrice, decimal maxPrice);
        List<Product> SearchProductByName(string name);


        List<Sales> GetSales();
        int AddSale(double amount, DateTime datetime, SaleItem saleItem);
        void RemoveSales(int id);
        List<Sales> ShowSalesByDateRange(DateTime minDate, DateTime maxDate);
        List<Sales> ShowSalesByExactDate(DateTime datetime);
        List<Sales> ShowSaleByPriceRange(decimal minAmount, decimal maxAmount);
        List<Sales> ShowSaleByID(int id);



    }
}
