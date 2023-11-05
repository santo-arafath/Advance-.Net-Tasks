using form_validation_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace form_validation_1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {

            ViewBag.hello = "get method";

            return View();

        }
        [HttpPost]
        public ActionResult Registration(Registration reg)
          {

                return View(reg);
          }




         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        

        


    }
}