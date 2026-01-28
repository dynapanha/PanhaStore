using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    internal class ExchangeRate
    {
        private string id;
        private int rate;

        public ExchangeRate(string id, int rate)
        {
            this.Id = id;
            this.Rate = rate;
        }
        public ExchangeRate()
        {

        }
        public string Id { get => id; set => id = value; }
        public int Rate { get => rate; set => rate = value; }
    }
}
