using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemID { get; set; }

        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<ST> STs { get; set; }

        public bool Status { get; set; }
    }
}