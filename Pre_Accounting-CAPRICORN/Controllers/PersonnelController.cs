using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    [Authorize]
    public class PersonnelController : Controller
    {
        Context c = new Context();
        // GET: Personnel

        [Authorize(Roles = "A")]
        public ActionResult Index(string search)
        {
            var result = from p in c.Personnels
                         where p.Status == true
                         select p;

            if (!String.IsNullOrEmpty(search))
            {
                result = result.Where(x => x.PersonnelName.Contains(search));
            }
            return View(result.ToList());
        }

        
        public ActionResult NewPersonnel()
        {
            List<SelectListItem> titles = new List<SelectListItem>() {
                new SelectListItem {
                    Text = "Admin", Value = "0"
                },
                new SelectListItem {
                    Text = "Sales Representative", Value = "1"
                }
            };

            ViewBag.titles = titles;
            return View();
        }


        [HttpPost]
        public ActionResult NewPersonnel(Personnel p)
        {
            c.Personnels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePersonnel(int id)
        {
            var result = c.Personnels.Find(id);
            if (result != null)
            {
                result.Status = false;
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult BringPersonnel(int id)
        {
            List<SelectListItem> titles = new List<SelectListItem>() {
            new SelectListItem {
             Text = "Admin", Value = "0"
        },
        new SelectListItem {
            Text = "Sales Representative", Value = "1"
        }, };
            ViewBag.titles = titles;
            var result = c.Personnels.Find(id);
            return View("BringPersonnel", result);
        }

        [HttpPost]
        public ActionResult UpdatePersonnel(Personnel p)
        {
            var result = c.Personnels.Find(p.PersonnelID);
            result.PersonnelID = p.PersonnelID;
            result.PersonnelName = p.PersonnelName;
            result.Title = p.Title;
            result.Username = p.Username;
            result.Password = p.Password;
            result.Authority = p.Authority;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonnelDetails(int id)
        {
            var result = c.InvoiceItems.Where(x => x.Invoice.PersonnelID == id).ToList();
            return View(result);
        }
    }
}