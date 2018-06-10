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

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id ==0)
            {
                return View(new InstructorModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("INSTRUCTORs/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<InstructorModel>().Result);
            }
            
        }
        [HttpPost]
        public ActionResult AddOrEdit(InstructorModel emp)
        {
            if(emp.Instructor_ID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("INSTRUCTORs", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("INSTRUCTORs/"+emp.Instructor_ID, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("INSTRUCTORs/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}