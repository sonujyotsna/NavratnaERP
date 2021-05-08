using NavratnaERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NavratnaERP.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int EmpId)
        {
            ViewBag.EmpId = EmpId;
            return View();
        }
        public ActionResult ListofEmployee()
        {
            return View();
        }
        public ActionResult EmployeeIcard()
        {
             var model = new EmployeeModel().GetIcardList("Navratna Mauganese Products LLP.") ;
            return View("..//Employee//EmployeeIcard",model);
        }
        public ActionResult EmployeeIcardM()
        {
            var model = new EmployeeModel().GetIcardList("Manmohan Minerals & Chemicals Pvt. Ltd.-B");
            return View("..//Employee//EmployeeIcardM", model);
        }
        public ActionResult EmployeeIcardMC()
        {
            var model = new EmployeeModel().GetIcardList("Manmohan Minerals & Chemicals Pvt.Ltd.-C");
            return View("..//Employee//EmployeeIcardMC", model);
        }
        public ActionResult SaveRegistration(EmployeeModel model)
        {
            try
            {
                HttpPostedFileBase fb = null;
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    fb = Request.Files[i];
                }

                return Json(new { models = new EmployeeModel().SaveRegistration(fb, model) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { models = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetRegistrationList(string CompanyName)
        {
            try
            {
                 return Json(new { model = (new EmployeeModel().GetRegistrationList( CompanyName)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetEditRegistration(int EmpId)
        {
            try
            {
               
               
                return Json(new { model = (new EmployeeModel().GetEditRegistration(EmpId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult deleteRegistration(int EmpId)
        {
            try
            {


                return Json(new { model = (new EmployeeModel().deleteRegistration(EmpId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
       
    }
}