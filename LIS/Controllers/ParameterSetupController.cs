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
    public class ParameterSetupController : Controller
    {
        // GET: ParameterSetup
        public ActionResult ParameterList()
        {
            return View();
        }

        public ActionResult AddNewParameter()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ParameterSetupUpdate(string Id, string TestCode, string ParameterName, string ParameterType, string Unit, string Range, string IsActive)
        {
            ParameterSetupManager m = new ParameterSetupManager();
            m.Id = Id;
            m.TestCode = TestCode;
            m.ParameterName = ParameterName;
            m.ParameterType = ParameterType;
            m.Unit = Unit;
            m.Range = Range;
            m.IsActive = IsActive;
            var a = m.ParameterSetupUpdateManager();
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ParameterSetupRead()
        {
            DataTable dt = new DataTable();
            ParameterSetupManager obj = new ParameterSetupManager();
            dt = obj.ParameterSetupReadCls();

            List<ParameterSetupManager> clslist = ParameterSetupManager.PS_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ParameterSetupReadById(string Id)
        {
            DataTable dt = new DataTable();
            ParameterSetupManager obj = new ParameterSetupManager();
            dt = obj.ParameterReadById(Convert.ToInt32(Id));

            var a = JsonHelper.DataTableToJSON(dt);

            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteParameter(string Id)
        {
            ParameterSetupManager obj = new ParameterSetupManager();
            obj.Id = Id;
            var a = obj.DeleteParameter();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}