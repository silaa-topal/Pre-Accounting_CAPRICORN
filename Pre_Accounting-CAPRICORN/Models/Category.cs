using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
      
        [Required(ErrorMessage ="Category name is required!")]
        [DisplayName("Category Name")]
        [Remote("IsCategoryNameExist", "Category", AdditionalFields = "Id",
               ErrorMessage = "*Category name already exists!Try again.")]
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}