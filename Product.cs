using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    internal class Product
    {
        private int id;
        private long barcode;
        private string name;
        private int qty;
        private double priceIn, priceOut;
        private int cateId;

        public Product()
        {

        }

        public Product(int id, long barcode, string name, int qty, double priceIn, double priceOut, int cateId)
        {
            this.Id = id;
            this.Barcode = barcode;
            this.Name = name;
            this.Qty = qty;
            this.PriceIn = priceIn;
            this.PriceOut = priceOut;
            this.CateId = cateId;
        }

        public int Id { get => id; set => id = value; }
        public long Barcode { get => barcode; set => barcode = value; }
        public string Name { get => name; set => name = value; }
        public int Qty { get => qty; set => qty = value; }
        public double PriceIn { get => priceIn; set => priceIn = value; }
        public double PriceOut { get => priceOut; set => priceOut = value; }
        public int CateId { get => cateId; set => cateId = value; }
    }
}
