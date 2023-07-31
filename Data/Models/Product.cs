using Final_Project.Data.Common;
using Final_Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Models
{
    public class Product : BaseEntity
    {
        private static int count =0;//counts product instance
        //properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, Category category, int quantity)//constructor
        {
            Name = name;
            Price = price;
            Category = category;
            Quantity = quantity;
            
            ID = count;
            count++;
        }
    }
}
