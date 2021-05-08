using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NavratnaERP.Models;
namespace NavratnaERP.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginIn(LoginModel model)
        {
             if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password=="Navratna@123")
                {
                   
                    return RedirectToAction("UserDashBoard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User name or password.");
                }

            }
            return View("..\\Login\\Index", model);
        }

        public ActionResult UserDashBoard()
        {
            return View("..\\Employee\\ListOfEmployee");
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("..\\Login\\Index");
        }
    }
}