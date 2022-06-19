using System;
using System.Collections.Generic;
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

    }
}