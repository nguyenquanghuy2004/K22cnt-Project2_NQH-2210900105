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
    
    public partial class REVIEW
    {
        public int review_id { get; set; }
        public byte rating { get; set; }
        public string comment { get; set; }
        public int member_id { get; set; }
        public int product_id { get; set; }
    
        public virtual MEMBER MEMBER { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
    }
}
