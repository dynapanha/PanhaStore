using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class OrderDetail
    {
        private int productId, qty;
        private double priceIn, priceOut;
        private string productName;
        public OrderDetail() 
        {

        }
        public OrderDetail(int productId, int qty, double priceIn, double priceOut, string productName)
        {
            this.ProductId = productId;
            this.Qty = qty;
            this.PriceIn = priceIn;
            this.PriceOut = priceOut;
            this.ProductName = productName;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int Qty { get => qty; set => qty = value; }
        public double PriceIn { get => priceIn; set => priceIn = value; }
        public double PriceOut { get => priceOut; set => priceOut = value; }
        public string ProductName { get => productName; set => productName = value; }
    }
}
