//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Advanced_Accounting_Customer_Tracker
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerServiceAssociative
    {
        public int ServiceID { get; set; }
        public int CustomerID { get; set; }
        public int Id { get; set; }
        public Nullable<bool> Performed { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public string Frequency { get; set; }
        public Nullable<bool> Reminder { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }
    }
}