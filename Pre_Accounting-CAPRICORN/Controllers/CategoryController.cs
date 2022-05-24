using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers

{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(string search)
        {
            var values = from v in c.Categories
                         where v.Status == true
                         select v;

            if (!String.IsNullOrEmpty(search))
            {
                values = values.Where(v => v.CategoryName.Contains(search));
            }
            return View(values.ToList());
        }

        [Authorize(Roles= "A")]
        [HttpGet] //sayfayı getir
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost] //butonu çalıştır
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult IsCategoryNameExist(string CategoryName, int? Id)
        {
            var validateName = c.Categories.FirstOrDefault
                                (x => x.CategoryName == CategoryName && x.CategoryID != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "A")]
        public ActionResult DeleteCategory(int id)
        {
            var cat = c.Categories.Find(id);
            if (cat != null)
            {
                cat.Status = false;

                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "A")]
        [HttpGet] //sayfayı getir
        public ActionResult BringCategory(int id)
        {
            var cat = c.Categories.Find(id);

            return View("BringCategory", cat);
        }

        [HttpPost] //butonu çalıştır 
        public ActionResult EditCategory(Category k)
        {
            var ctg = c.Categories.Find(k.CategoryID);
            ctg.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}