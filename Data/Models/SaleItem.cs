using Final_Project.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Models
{
    public class SaleItem : BaseEntity
    {
        private static int count = 0;

        public Product Product { get; set; }
        public int Quantity { get; set; }

        public SaleItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            ID = count;
            count++;
        }

    }
}
