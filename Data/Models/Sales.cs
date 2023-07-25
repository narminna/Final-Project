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

        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public SaleItem SaleItem { get; set; }

        public Sales(double amount, DateTime datetime)
        {
            Amount = amount;
            DateTime = datetime;

            ID = count;
            count++;

        }
    }
}
