using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NQH_project2_2210900105.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
    }
}