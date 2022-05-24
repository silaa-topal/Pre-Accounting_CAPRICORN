using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Personnel
    {
        [Key]
        public int PersonnelID { get; set; }
        public string  PersonnelName { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage ="*This field is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*This field is required!")]
        public string Password { get; set; }
        public string Authority { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}