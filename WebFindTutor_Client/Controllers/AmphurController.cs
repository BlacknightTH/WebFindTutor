using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;

namespace WebFindTutor_Client.Controllers
{
    public class AmphurController : Controller
    {
        // GET: Amphur
        public ActionResult Index()
        {
            IEnumerable<AmphurModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("AMPHURs").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<AmphurModel>>().Result;
            
            return View(istList);
        }
    }
}