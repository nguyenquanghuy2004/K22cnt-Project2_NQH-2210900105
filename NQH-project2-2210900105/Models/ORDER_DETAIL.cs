//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NQH_project2_2210900105.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDER_DETAIL
    {
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal product_price { get; set; }
    
        public virtual ORDERS ORDERS { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}