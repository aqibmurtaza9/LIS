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
    public class LaboratorySetupController : Controller
    {
        // GET: LaboratorySetup
        public ActionResult LaboratorySetupList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LaboratorySetupUpdate(string Id, string Name, string Description, string IsActive, string IsDeleted)
        {
            LaboratoryManager m = new LaboratoryManager();
            m.Id = Id;
            m.Name = Name;
            m.Description = Description;
            m.IsActive = IsActive;

            var a = m.LaboratorySetupUpdate();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LaboratorySetupRead()
        {
            DataTable dt = new DataTable();
            LaboratoryManager obj = new LaboratoryManager();
            dt = obj.LaboratorySetupRead();

            List<LaboratoryManager> clslist = LaboratoryManager.LS_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LaboratoryRead(string Id)
        {
            DataTable dt = new DataTable();
            LaboratoryManager obj = new LaboratoryManager();
            obj.Id = Id;
            dt = obj.LaboratoryRead();

            var a = JsonHelper.DataTableToJSON(dt);
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteLabSetup(string Id)
        {

            LaboratoryManager obj = new LaboratoryManager();
            obj.Id = Id;

            var a = obj.DeleteLabSetup();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

    }
}