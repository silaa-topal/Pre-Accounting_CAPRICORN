using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Brand is required!")]
        public string Brand { get; set; }
        //[Remote("IsProductNameExist", "Product", AdditionalFields = "Brand",
        //     ErrorMessage = "Product name already exists")]
        [Required(ErrorMessage = "Product name is required!")]
        public string ProductName { get; set; }
        public int? Stock { get; set; }
        public bool Status { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}