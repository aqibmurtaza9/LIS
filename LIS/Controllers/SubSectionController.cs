using LISBusiness.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIS.Controllers
{
    public class SubSectionController : Controller
    {
        // GET: SubSection
        public ActionResult SubSectionList()
        {
            return View();
        }

        public ActionResult SubSectionListRead()
        {
            DataTable dt = new DataTable();
            SubSectionManager obj = new SubSectionManager();
            dt = obj.AllRead();

            List<SubSectionManager> clslist = SubSectionManager.ES_List(dt);
            var a = new { data = clslist };
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}