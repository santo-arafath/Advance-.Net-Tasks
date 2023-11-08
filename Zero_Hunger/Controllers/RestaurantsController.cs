using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.EF;
using static System.Collections.Specialized.BitVector32;

namespace Zero_Hunger.Controllers
{
    public class RestaurantsController : Controller
    {
        
        public ActionResult login()
        {

           
            return View();
        }

       

        public ActionResult Dashboard() 
        {
            
            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities1();
            var data = (from s in db.Requests
                        where s.rest_id == us_id && (s.status == "pendding" || s.status =="Assigned")
                        select s).ToList();
            return View(data); 
        
        }

        [HttpGet]
        public ActionResult Show_all_donation()
        {
            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities1();
            var data = (from s in db.Requests
                        where s.rest_id == us_id
                        select s).ToList();
            return View(data);

            
        }



        [HttpGet]
        public ActionResult Request_send() {

            ViewBag.now=new DateTime();

            ViewBag.res_idd= Convert.ToInt32(Session["res_id"]);


            var us_id = Convert.ToInt32(Session["res_id"]);

            var db = new Zero_Hunger_dbEntities1();
            var data = (from s in db.Restaurants
                        where s.restaurants_id == us_id
                        select s).FirstOrDefault();

            return View(data);

        }


        [HttpPost]
        public ActionResult Request_send(Request r)
        {
            var db=new Zero_Hunger_dbEntities1();

            db.Requests.Add(r);
            db.SaveChanges();

            return RedirectToAction("Dashboard");

        }
    }
}