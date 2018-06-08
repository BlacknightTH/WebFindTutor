using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebFindTutor_Client.Models;


namespace WebFindTutor_Client.Controllers
{
    public class ProvinceController : Controller
    {
        // GET: Province
        public ActionResult Index()
        {
            IEnumerable<ProvinceModel> istList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("PROVINCEs").Result;
            istList = response.Content.ReadAsAsync<IEnumerable<ProvinceModel>>().Result;
            return View(istList);
        }
    }
}