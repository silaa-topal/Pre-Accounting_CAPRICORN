using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer name is required!")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Customer e-mail address is required!")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Maximum length is 50")]
        public string CustomerMailAddress { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}