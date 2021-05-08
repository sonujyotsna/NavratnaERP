using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NavratnaERP.Models;

namespace NavratnaERP.Controllers
{
    public class EmployeeDetailController : Controller
    {
        // GET: EmployeeDetail
        public ActionResult Index(int EmpId)
        {
            ViewBag.EmpId = EmpId;
            return View();
        }
        public ActionResult FamilyDetails()
        {
            return View();
        }
        public ActionResult SaveRegistration(EmployeeDetailModel model)
        {
            return Json(new { message = (new EmployeeDetailModel().SaveRegistration(model)) }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetRegistrationList(int EmpId)
        {
            try
            {
                return Json(new { model = (new EmployeeDetailModel().GetRegistrationList(EmpId)) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}