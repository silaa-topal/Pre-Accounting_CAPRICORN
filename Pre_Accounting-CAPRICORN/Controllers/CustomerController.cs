using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        public ActionResult Index(string search)
        {
            var result = from k in c.Customers
                         where k.Status == true
                         select k;

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(k => k.CustomerName.Contains(search));
            }
            return View(result.ToList());
        }

        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customer k)
        {
            if(c.Customers.Any(x => x.CustomerMailAddress == k.CustomerMailAddress))
            {
                ViewBag.msg = "Customer e-mail address must be unique!";
                return View();
            }
                
            if (ModelState.IsValid)
            {
                k.Status = true;
                c.Customers.Add(k);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(k);

        }

        public ActionResult DeleteCustomer(int id)
        {
            var cus = c.Customers.Find(id);
            if (cus != null)
            {
                cus.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            var result = c.Customers.Find(id);
            return View("UpdateCustomer", result);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer k)
        {
            if (!ModelState.IsValid)
            {
                return View(k);
            }
            var result = c.Customers.Find(k.CustomerID);
            result.CustomerID = k.CustomerID;
            result.CustomerName = k.CustomerName;
            result.CustomerCity = k.CustomerCity;
            result.CustomerMailAddress = k.CustomerMailAddress;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerDetails(int id)
        {
            var result = c.InvoiceItems.Where(x => x.Invoice.CustomerID == id).ToList();
            ViewBag.res = result;
            var count = result.Count();
            if(count <= 0)
            {
                ViewBag.msg = "No detail to be shown.";
            }
            return View(result);
        }
    }
}