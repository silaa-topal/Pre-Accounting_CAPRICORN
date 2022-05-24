using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class ST
    {
        [Key]
        public int STid { get; set; }

        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int? RemainingStock { get; set; }

        public int InvoiceItemID { get; set; }
        public virtual InvoiceItem InvoiceItem { get; set; }
    }
}