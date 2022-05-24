using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Required]
        [DisplayName("Serial-Row No")]
        [Remote("IsInvoiceExist", "Invoice", AdditionalFields = "Id",
                ErrorMessage = "Invoice row number already exists")]
        [Column(TypeName = "Varchar")]
        [StringLength(8)]
        public string InvoiceSerialRowNo { get; set; }

        public string InvoiceDate { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string InvoiceTime { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxOffice { get; set; }

        [Required]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Type { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

        public virtual ICollection<ACT> ACTs { get; set; }

        public int PersonnelID { get; set; }
        public virtual Personnel Personnel { get; set; }

        public bool Status { get; set; }

    }
}