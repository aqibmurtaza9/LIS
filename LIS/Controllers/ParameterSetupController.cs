using System;
using System.Collections.Generic;
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


    }
}