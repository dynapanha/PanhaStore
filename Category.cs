using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    internal class Category
    {
        private string id;
        private string categoryName;
        public Category()
        {

        }
        public Category(string id, string categoryName)
        {
            this.Id = id;
            this.CategoryName = categoryName;
        }

        public string Id { get => id; set => id = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }
}
