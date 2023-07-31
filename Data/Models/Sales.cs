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
        private static int count = 0;//counts sales instance
        //sale properties
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public List<SaleItem> SaleItem { get; set; }

        public Sales(decimal amount, List<SaleItem> saleItem, DateTime datetime)//constructors
        {
            Amount = amount;
            SaleItem = saleItem;
            DateTime = datetime;

            ID = count;
            count++;
        }
        public override string ToString()//provides a custom string representation of the sale instance
        {
            return string.Join(", ", SaleItem.Select(item => item.Product.Name));
        }
    }    
}
