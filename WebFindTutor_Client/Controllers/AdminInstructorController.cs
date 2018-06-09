using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;

namespace WebFindTutor_Client.Controllers
{
    public class AdminInstructorController : Controller
    {
        // GET: AdminInstructor
        public ActionResult Index()
        {
            IEnumerable<InstructorModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("INSTRUCTORs").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<InstructorModel>>().Result;
            return View(istList);
        }
    }
}