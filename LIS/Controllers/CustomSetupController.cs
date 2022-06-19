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
    public class CustomSetupController : Controller
    {
        CustomSetupManager _customSetupManager = new CustomSetupManager();
        // GET: Custom Setup
        public ActionResult CustomSetupList()
        {

            return View();

        }

        public JsonResult GetCustomSetupList()
        {
            DataTable dt = new DataTable();
            dt = _customSetupManager.CustomSetupRead();

            List<CustomSetupManager> clslist = CustomSetupManager.ES_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetupPreLoad(string Id)
        {
            DataTable dt = new DataTable();
            CustomSetupManager obj = new CustomSetupManager();
            dt = obj.SetupPreLoad(Id);

            var a = JsonHelper.DataTableToJSON(dt);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        //On change select type: Load CustomSetupList Jquery DataTable row
        [HttpGet]
        public JsonResult CustomSetupListReadById(string Id)
        {
            DataTable dt = new DataTable();
            CustomSetupManager obj = new CustomSetupManager();
            obj.Id = Id;
            dt = obj.CustomTableRead();

            List<CustomSetupManager> clslist = CustomSetupManager.ES_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }



        public JsonResult CustomSetupUpdate(string Id, string Description, string MasterId, string IsActive  /*string IsDeleted*/)
        {
            CustomSetupManager obj = new CustomSetupManager();
            obj.Id = Id;
            obj.Description = Description;
            obj.MasterId = MasterId;
            obj.IsActive = IsActive;
            //m.IsDeleted = IsDeleted;

            var a = obj.CustomSetupUpdate();
            return Json(a, JsonRequestBehavior.AllowGet); ;
        }


        //onclick edit row
        public JsonResult CustomSetupReadById(string Id)
        {
            DataTable dt = new DataTable();
            CustomSetupManager obj = new CustomSetupManager();
            dt = obj.CustomRead(Convert.ToInt32(Id));

            var a = JsonHelper.DataTableToJSON(dt);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCustomSetupById(string Id)
        {
            CustomSetupManager obj = new CustomSetupManager();
            obj.Id = Id;
            var a = obj.DeleteCustomSetup();

            return Json(a, JsonRequestBehavior.AllowGet);
        }




    }
}