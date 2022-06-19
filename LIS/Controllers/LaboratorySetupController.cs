using System;
using System.Collections.Generic;
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
    }
}