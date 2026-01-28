using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class ReportDetail
    {
        private string productName;
        private double price;
        private int qty;
 
        public ReportDetail()
        {

        }

        public ReportDetail(string productName, double price, int qty)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Qty = qty;
        }

        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}
