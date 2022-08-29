using LISBusiness.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Controllers
{
    public class LabRequestController : Controller
    {
        // GET: LabRequest
        public ActionResult LabRequestList()
        {
            return View();
        }

        public ActionResult LabRequestEntry()
        {
            return View();
        }

        public JsonResult LabRequestDetail(string mrno, string Status, string TestCode, string IRSType, string UrgentType)
        {
            LabRequestManager cls = new LabRequestManager();
            cls.MRNo = mrno;
            cls.Status = Status;
            cls.TestCode = TestCode;
            cls.IRSType = IRSType;
            cls.UrgentType = UrgentType;
            var a = cls.LabRequestDetail();
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}
