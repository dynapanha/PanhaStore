using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Order
    {
        private int orderId;
        private DateTime date;
        private DateTime time;
        private int discount;
        private double amount;
        private string seller;
        private int exchangeId, discountId;

        public int OrderId { get => orderId; set => orderId = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
        public int Discount { get => discount; set => discount = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Seller { get => seller; set => seller = value; }
        public int ExchangeId { get => exchangeId; set => exchangeId = value; }
        public int DiscountId { get => discountId; set => discountId = value; }

        public Order(int orderId, DateTime date, DateTime time, int discount, double amount, string seller, int exchangeId, int discountId)
        {
            this.OrderId = orderId;
            this.Date = date;
            this.Time = time;
            this.Discount = discount;
            this.Amount = amount;
            this.Seller = seller;
            this.ExchangeId = exchangeId;
            this.DiscountId = discountId;
        }

        public Order()
        {

        }
    }
}
