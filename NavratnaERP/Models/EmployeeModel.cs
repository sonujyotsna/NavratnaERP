using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NavratnaERP.Data;
using System.IO;

namespace NavratnaERP.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string MobNo { get; set; }
        public string AlternetMobNo { get; set; }
        public string AdharDetail { get; set; }
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public System.DateTime DateofJoining { get; set; }
        public string DateofJoiningString { get; set; }
        public System.DateTime DateofLeaving { get; set; }
        public string DateofLeavingString { get; set; }
        public string Photo { get; set; }

        public string SaveRegistration(HttpPostedFileBase fb, EmployeeModel model)
        {
            string message = "";
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            string filePath = "";
            string fileName = "";
            string sysFileName = "";

            if (model.EmpId == 0)
            {
                if (fb != null && fb.ContentLength > 0)
                {
                    filePath = HttpContext.Current.Server.MapPath("~/Content/images/");
                    DirectoryInfo di = new DirectoryInfo(filePath);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    fileName = fb.FileName;
                    sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                    fb.SaveAs(filePath + "//" + sysFileName);
                    if (!string.IsNullOrWhiteSpace(fb.FileName))
                    {
                        string afileName = HttpContext.Current.Server.MapPath("~/Content/images/") + "/" + sysFileName;

                    }
                }
                var saveRegistration = new tblEmployee()
                {
                    FullName = model.FullName,
                    PresentAddress = model.PresentAddress,
                    PermanentAddress = model.PermanentAddress,
                    MobNo = model.MobNo,
                    AlternetMobNo = model.AlternetMobNo,
                    AdharDetail = model.AdharDetail,
                    CompanyName = model.CompanyName,
                    Post = model.Post,
                    DateofJoining = model.DateofJoining,
                    DateofLeaving = model.DateofLeaving,
                    Photo = sysFileName,
                };
                db.tblEmployees.Add(saveRegistration);
                db.SaveChanges();
                message = "Data saved successfully";
                //return message;
            }
            else
            {
                if (fb != null && fb.ContentLength > 0)
                {
                    filePath = HttpContext.Current.Server.MapPath("~/Content/images/");
                    DirectoryInfo di = new DirectoryInfo(filePath);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    fileName = fb.FileName;
                    sysFileName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(fb.FileName);
                    fb.SaveAs(filePath + "//" + sysFileName);
                    if (!string.IsNullOrWhiteSpace(fb.FileName))
                    {
                        string afileName = HttpContext.Current.Server.MapPath("~/Content/images/") + "/" + sysFileName;

                    }
                }
                var getRegistrationData = db.tblEmployees.Where(p => p.EmpId == model.EmpId).FirstOrDefault();
                if (getRegistrationData != null)
                {

                    getRegistrationData.FullName = model.FullName;
                    getRegistrationData.PresentAddress = model.PresentAddress;
                    getRegistrationData.PermanentAddress = model.PermanentAddress;
                    getRegistrationData.MobNo = model.MobNo;
                    getRegistrationData.AlternetMobNo = model.AlternetMobNo;
                    getRegistrationData.AdharDetail = model.AdharDetail;
                    getRegistrationData.CompanyName = model.CompanyName;
                    getRegistrationData.Post = model.Post;
                    getRegistrationData.DateofJoining = model.DateofJoining;
                    getRegistrationData.DateofLeaving = model.DateofLeaving;
                    if (fb != null && fb.ContentLength > 0)
                    {
                        getRegistrationData.Photo = sysFileName;
                    }

                };

                db.SaveChanges();
                message = "Data Updated Sucessfully....";
            }
                return message;

            
        }
        public List<EmployeeModel> GetRegistrationList( string CompanyName)
        {
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            List<EmployeeModel> str = new List<EmployeeModel>();
            var RegistrationList = db.tblEmployees.Where( p=>p.CompanyName==CompanyName).ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new EmployeeModel()
                    {
                        EmpId = reg.EmpId,
                        FullName = reg.FullName,
                        PresentAddress = reg.PresentAddress,
                        PermanentAddress = reg.PermanentAddress,
                        MobNo = reg.MobNo,
                        AlternetMobNo = reg.AlternetMobNo,
                        AdharDetail = reg.AdharDetail,
                        CompanyName = reg.CompanyName,
                        Post = reg.Post,
                        DateofJoiningString = reg.DateofJoining.ToString("dd/MM/yyyy"),
                        DateofLeavingString = reg.DateofLeaving.ToString("dd/MM/yyyy"),
                        Photo = reg.Photo,
                    });
                }
            }
            return str;
        }

        public List<EmployeeModel> GetIcardList(string Company)
        {
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            List<EmployeeModel> str = new List<EmployeeModel>();
            var RegistrationList = db.tblEmployees.Where(p=>p.CompanyName==Company).ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new EmployeeModel()
                    {
                        EmpId = reg.EmpId,
                        FullName = reg.FullName,
                        PresentAddress = reg.PresentAddress,
                        PermanentAddress = reg.PermanentAddress,
                        MobNo = reg.MobNo,
                        AlternetMobNo = reg.AlternetMobNo,
                        AdharDetail = reg.AdharDetail,
                        CompanyName = reg.CompanyName,
                        Post = reg.Post,
                        DateofJoiningString = reg.DateofJoining.ToString("dd/MM/yyyy"),
                        DateofLeavingString = reg.DateofLeaving.ToString("dd/MM/yyyy"),
                        Photo = reg.Photo,
                    });
                }
            }
            return str;
        }

        public EmployeeModel GetEditRegistration(int EmpId)
        {
            EmployeeModel model = new EmployeeModel();
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            var getRegistrationData = db.tblEmployees.Where(p => p.EmpId == EmpId).FirstOrDefault();

            if (getRegistrationData != null)
            {
                model.EmpId = getRegistrationData.EmpId;
                model.FullName = getRegistrationData.FullName;
                model.PresentAddress = getRegistrationData.PresentAddress;
                model.PermanentAddress = getRegistrationData.PermanentAddress;
                model.MobNo = getRegistrationData.MobNo;
                model.AlternetMobNo = getRegistrationData.AlternetMobNo;
                model.AdharDetail = getRegistrationData.AdharDetail;
                model.CompanyName = getRegistrationData.CompanyName;
                model.Post = getRegistrationData.Post;
                model.DateofJoining = getRegistrationData.DateofJoining;
                model.DateofJoiningString = getRegistrationData.DateofJoining.ToString("dd/MM/yyyy");
                model.DateofLeaving = getRegistrationData.DateofLeaving;
                model.DateofLeavingString = getRegistrationData.DateofLeaving.ToString("dd/MM/yyyy");
                model.Photo = getRegistrationData.Photo;
            };

            return model;
        }
        public string deleteRegistration(int EmpId)
        {
            String Message = "";
            
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            var deleteRecord = db.tblEmployees.Where(p => p.EmpId == EmpId).FirstOrDefault();

            if (deleteRecord != null)
            {
                db.tblEmployees.Remove(deleteRecord);
            };
            db.SaveChanges();
            Message = "Record Deleted Successfully";
            return Message;
        }
            
    }
}


