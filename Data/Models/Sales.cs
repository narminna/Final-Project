using Final_Project.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Data.Models
{
    public class Sales : BaseEntity
    {
        private static int count = 0;

        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public List<SaleItem> SaleItem { get; set; }

        public Sales(decimal amount, List<SaleItem> saleItem, DateTime datetime)
        {
            Amount = amount;
            SaleItem = saleItem;
            DateTime = datetime;

            ID = count;
            count++;
        }
        public override string ToString()
        {
            return string.Join(", ", SaleItem.Select(item => item.Product.Name));
        }
    }    
}
