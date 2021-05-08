using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NavratnaERP.Data;

namespace NavratnaERP.Models
{
    public class EmployeeDetailModel
    {
        public int EmpDetailsId { get; set; }
        public int EmpId { get; set; }
        public string FamilyMemberName { get; set; }
        public string MemberRelation { get; set; }
        public string PresentAddress { get; set; }
        public string MobNo { get; set; }
        public string AlternetMobNo { get; set; }
        public string AdharDetail { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }

        public string SaveRegistration(EmployeeDetailModel model)
        {
            string message = "";
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            var saveRegistration = new tblEmployeeDetail()
            {
                EmpId = model.EmpId,
                FamilyMemberName = model.FamilyMemberName,
                MemberRelation = model.MemberRelation,
                PresentAddress = model.PresentAddress,
                MobNo = model.MobNo,
                AlternetMobNo = model.AlternetMobNo,
                AdharDetail = model.AdharDetail,
                Occupation = model.Occupation,
                CompanyName = model.CompanyName,
               
            };
            db.tblEmployeeDetails.Add(saveRegistration);
            db.SaveChanges();
            message = "Data saved successfully";
            return message;
        }
        public List<EmployeeDetailModel> GetRegistrationList(int EmpId)
        {
            NavratnaERPEntities1 db = new NavratnaERPEntities1();
            List<EmployeeDetailModel> str = new List<EmployeeDetailModel>();
            var RegistrationList = db.tblEmployeeDetails.Where(p => p.EmpId == EmpId).ToList();
            if (RegistrationList != null)
            {
                foreach (var reg in RegistrationList)
                {
                    str.Add(new EmployeeDetailModel()
                    {
                        EmpDetailsId = reg.EmpDetailsId,
                        EmpId = reg.EmpId,
                        FamilyMemberName = reg.FamilyMemberName,
                        MemberRelation = reg.MemberRelation,
                        PresentAddress = reg.PresentAddress,
                        MobNo = reg.MobNo,
                        AlternetMobNo = reg.AlternetMobNo,
                        AdharDetail = reg.AdharDetail,
                        Occupation = reg.Occupation,
                        CompanyName = reg.CompanyName,

                    });
                }
            }
            return str;
        }
    }
}
    
