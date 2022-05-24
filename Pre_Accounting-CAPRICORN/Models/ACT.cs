using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class ACT
    {
        [Key]
        public int ACTid { get; set; }

        public decimal? TotalAmount { get; set; }
        public string Type { get; set; }
        public string CustomerName { get; set; }

        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}