using PatientsTypeahead.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsTypeahead.Controllers
{
    public class PatientsController : Controller
    {
        // GET: when application loads show the Index view
        public ActionResult Index()
        {
            return View();
        }

        // post method for searching the patient
        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            // invoke the static method by passing the first name / last name
            // return the json to the ui.
            return Json(PatientData.ReadPatients(prefix));
        }
    }
}
