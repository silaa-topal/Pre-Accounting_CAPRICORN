using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        // GET: Statistics
        [Authorize]
        public ActionResult Index()
        {
            var totalCustomer = c.Customers.Where(x => x.Status == true).Count().ToString();
            ViewBag.tc = totalCustomer;

            var totalPersonnel = c.Personnels.Where(x => x.Status == true).Count().ToString();
            ViewBag.tp = totalPersonnel;

            var totalProduct = c.Products.Where(x => x.Status == true).Count().ToString();
            ViewBag.tpr = totalProduct;

            var totalCategory = c.Categories.Count().ToString();
            ViewBag.tca = totalCategory;

            var totalStock = c.Products.Sum(x => x.Stock).ToString();
            ViewBag.ts = totalStock;

            //var totalBrand = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();

            var totalBrand = c.Products.Where(x => x.Status == true).Select(x => x.Brand).Distinct().Count().ToString();
            ViewBag.tb = totalBrand;

            //var criticLevel = c.Products.Count(x => x.Stock <= 20).ToString();
            var criticLevel = c.Products.Where(x => x.Stock <= 20 && x.Stock > 0).Count().ToString();
            ViewBag.cl = criticLevel;

            //var maxPriceProduct = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            //ViewBag.maxp = maxPriceProduct;

            //var minPriceProduct = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            //ViewBag.minp = minPriceProduct;

            //var maxBrand = c.Products.GroupBy(x => x.Brand).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            //ViewBag.mb = maxBrand;

            //var totalCash = c.SalesTransactions.Sum(x => x.TotalPrice).ToString();
            //ViewBag.tcash = totalCash;

            //var today = DateTime.Today;

            //var todaysSales = c.SalesTransactions.Count(x => x.Date == today).ToString();
            //ViewBag.tsale = todaysSales;


            //var todaysCash = c.SalesTransactions.Where(x => x.Date == today).Sum(y => y.TotalPrice).ToString();
            //if (todaysCash == "")
            //    todaysCash = "0";
            //ViewBag.todc = todaysCash;

            //var bestSeller = c.Products.Where(
            //    x => x.ProductID == (
            //    c.SalesTransactions.GroupBy(y => y.ProductID).OrderByDescending(z => z.Count()).Select(p => p.Key).FirstOrDefault()
            //    )
            //    ).Select(k => k.ProductName).FirstOrDefault();
            //ViewBag.bs = bestSeller;

            return View();
        }
    }
}
