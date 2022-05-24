using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class InvoiceSearchModel
    {
        public string InvoiceSerialRowNo { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceTime { get; set; }
        public string TaxOffice { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Type { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}