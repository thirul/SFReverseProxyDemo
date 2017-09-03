using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService
{
    public class ProductDetail
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public IEnumerable<OrderDetail> Orders{ get; set; }
    }
}
