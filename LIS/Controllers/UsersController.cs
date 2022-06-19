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
    public class UsersController : Controller
    {
        UserManager _userManager = new UserManager();

        public ActionResult UserList()
        {
            return View();
        }


        public ActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AddUser(string Id, string FirstName, string LastName, string UserName, string Email, string DepartmentCode, string PhoneNo, string Gender, string Cnic, string UserType,
                                       string AllowAuth, string IsActive, string IsDeleted)
        {

            UserManager m = new UserManager();
            m.Id = Id;
            m.FirstName = FirstName;
            m.LastName = LastName;
            m.UserName = UserName;
            m.Email = Email;
            m.DepartmentCode = DepartmentCode;
            m.PhoneNo = PhoneNo;
            m.Gender = Convert.ToInt32(Gender);
            m.Cnic = Cnic;
            m.UserType = Convert.ToInt32(UserType);
            m.AllowAuth = AllowAuth;
            m.IsActive = IsActive;
            m.IsDeleted = IsDeleted;
            m.UserRegistration();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

       

        [HttpGet]
        public JsonResult GetUserProfileList()
        {
            DataTable dt = new DataTable();
            dt = _userManager.GetUserProfileList();

            List<UserManager> clslist = UserManager.ES_List(dt);
            var data = new { data = clslist };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserProfileById(string Id)
        {
            DataTable dt = new DataTable();
            _userManager.Id = Id;
            dt = _userManager.GetUserProfile();

            var data =JsonHelper.DataTableToJSON(dt);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser(string Id)
        {
            _userManager.Id = Id;
            var data = _userManager.DeleteUser();

            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}