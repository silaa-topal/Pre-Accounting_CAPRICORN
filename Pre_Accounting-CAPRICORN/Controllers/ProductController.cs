using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string search)
        {
            var products = from p in c.Products
                           where p.Status == true
                           select p;

            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.ProductName.Contains(search));
            }
            return View(products.ToList());
        }
        
        public ActionResult NewProduct()
        {

            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.cat = category;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Product p)
        {
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.cat = category;

            if (c.Products.Any(x => x.ProductName == x.ProductName && x.Brand == x.Brand))
            {
                ModelState.AddModelError("ProductName", "*Product already exists!Try again.");
                return View();
            }                
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var result = c.Products.Find(id);
            if (result != null)
            {
                result.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult BringProduct(int id)
        {
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryID.ToString()
                                             }).ToList();
            ViewBag.cat = category;

            var result = c.Products.Find(id);
            return View("BringProduct", result);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product p)
        {
            var prdct = c.Products.Find(p.ProductID);
            prdct.ProductName = p.ProductName;
            prdct.Brand = p.Brand;
            prdct.Stock = p.Stock;
            prdct.CategoryID = p.CategoryID;
            prdct.ProductID = p.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}