using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.EF;

namespace Zero_Hunger.Controllers
{
    public class AdminController : Controller
    {
        
        public ActionResult Admin_Dashboard()
        {
            Session["order"] = null;
            var db = new Zero_Hunger_dbEntities1();

            var data = db.Requests.ToList();

            return View(data);
        }

        public ActionResult show_all()
        {

            var db = new Zero_Hunger_dbEntities1();

            var data = db.employees.ToList();

            return View(data);


             
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Session["order"]=id;
            var db = new Zero_Hunger_dbEntities1();

            var data = db.employees.ToList();

            return View(data);
        }

        public ActionResult Assign(int id)
        {
            int order_id = Convert.ToInt32(Session["order"]);

            var db = new Zero_Hunger_dbEntities1();

            var result = db.employees.SingleOrDefault(b => b.emp_id == id);
            if (result != null)
            {
                result.availability = "assigned";
                db.SaveChanges();
            }


            

            var result2 = db.Requests.SingleOrDefault(b => b.req_id == order_id);
            if (result2 != null)
            {
                result2.assigned_employee_id = id;
                result2.status = "Assigned";
                db.SaveChanges();
            }


            return RedirectToAction("Admin_Dashboard");
        }
    }
}