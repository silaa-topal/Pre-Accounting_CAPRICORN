using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pre_Accounting_CAPRICORN.Models
{
    public class Context: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ACT> ACTs { get; set; }
        public DbSet<ST> STs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Invoice>()
        //    .HasRequired<ACT>(s => s.ACT)
        //    .WithRequiredPrincipal(ad => ad.Invoice);
        //    //HasForeignKey<SalesTransaction>(ad => ad.AddressOfStudentId);

        //    modelBuilder.Entity<Product>()
        //    .HasRequired<InvoiceItem>(s => s.InvoiceItem)
        //    .WithRequiredPrincipal(ad => ad.Product);

        //}

    }
}