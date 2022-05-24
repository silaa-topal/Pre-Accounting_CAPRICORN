using Pre_Accounting_CAPRICORN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pre_Accounting_CAPRICORN.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login

        [HttpGet]
        public ActionResult PersonnelLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonnelLogin(Personnel p)
        {
            var invalidInfo = c.Personnels.FirstOrDefault(x => x.Username == p.Username && x.Password != p.Password);
            var info = c.Personnels.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (ModelState.IsValid)
            {        
                if(invalidInfo != null)
                {
                    ModelState.AddModelError("Username", "*Username not found or matched!");
                    return View();
                }

                else if (info != null)
                {
                    FormsAuthentication.SetAuthCookie(info.Username, false);
                    Session["Username"] = info.Username.ToString();
                    //kullanıcı adını sessiona taşıdım.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
                
            }
            return View(p);      
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("PersonnelLogin");
        }
    }
}