using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    internal class Discount
    {
        private string id;
        private int dis;
        public Discount()
        {

        }
        public Discount(string id, int dis)
        {
            this.id = id;
            this.dis = dis;
        }

        public string Id { get => id; set => id = value; }
        public int Dis { get => dis; set => dis = value; }
    }
}
