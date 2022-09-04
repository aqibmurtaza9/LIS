using LISBusiness.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Controllers
{
    public class TestSetupController : Controller
    {
        // GET: TestSetup
        public ActionResult TestSetupList()
        {
            return View();
        }

        public JsonResult ReadDT()
        {
            DataTable dt = new DataTable();
            TestSetupManager obj = new TestSetupManager();
            dt = obj.ReadDT();

            List<TestSetupManager> clslist = TestSetupManager.ES_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TestSetupUpdate(string Id,
         string TestName,
         string ShortDesp,
         string Type,
         string Section,
         string SubSection,
         string CptCode,
         string IsActive
         )
        {
            TestSetupManager Cls = new TestSetupManager();

            Cls.Id = Id;
            Cls.TestName = TestName;
            Cls.ShortDesp = ShortDesp;
            Cls.Type = Type;
            Cls.Section = Section;
            Cls.SubSection = SubSection;
            Cls.CptCode = CptCode;
            Cls.IsActive = IsActive;
            Cls.TestSetupUpdate();

            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }
}