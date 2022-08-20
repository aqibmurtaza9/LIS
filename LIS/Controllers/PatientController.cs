using LISBusiness.Managers;
using LISCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult PatientList()
        {
            return View();
        }

        public ActionResult AddNewPatient()
        {
            return View();
        }

        public JsonResult PatientUpdate(string ID, string FirstName, string LastName, string Email, string MobileNo, string Age, string MartialStatus, string Address, string Gender)
        {
            PatientManager cls = new PatientManager();
            cls.Id = ID;
            cls.FirstName = FirstName;
            cls.LastName = LastName;
            cls.Email = Email;
            cls.MobileNo = MobileNo;
            cls.Age = Age;
            cls.Gender = Gender;
            cls.MartialStatus = MartialStatus;
            cls.Address = Address;

            var a = cls.PatientClassUbdate();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }


        public JsonResult PatientListRead()
        {
            DataTable dt = new DataTable();
            PatientManager obj = new PatientManager();
            dt = obj.PatientListRead();

            List<PatientManager> clslist = PatientManager.ES_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PatientReadById(string ID)
        {
            DataTable dt = new DataTable();
            PatientManager obj = new PatientManager();
            obj.Id = ID;
            dt = obj.ClsPatientRead();

            var a = JsonHelper.DataTableToJSON(dt);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePatientById(string Id)
        {
            PatientManager obj = new PatientManager();
            obj.Id = Id;
            var a = obj.DeletePatientById();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

    }
}