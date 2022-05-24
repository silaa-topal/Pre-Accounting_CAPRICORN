using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class ACTViewModel
    {
        public int ACTid { get; set; }
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int Total { get; set; }
        public string Type { get; set; }
    }
}