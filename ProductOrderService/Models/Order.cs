using System;
using System.Collections.Generic;

namespace ProductOrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
    }
}