using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public DateTime  OrderDate { get; set; }
        public string OrderInfo { get; set; }
    }
}
