using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.EF;

namespace Zero_Hunger.Controllers
{
    public class EmployeeController : Controller
    {
        
        public ActionResult Employee_Dashboard()
        {
            int emp_id = Convert.ToInt32(Session["emp_id"]);
            var db = new Zero_Hunger_dbEntities1();

            var data =(from s in db.Requests
                       where s.assigned_employee_id == emp_id
                       select s).ToList();

            return View(data);
        }


        public ActionResult Collect(int id)
        {

            int emp_id = Convert.ToInt32(Session["emp"]);

            var db = new Zero_Hunger_dbEntities1();

            var result = db.employees.SingleOrDefault(b => b.emp_id == emp_id);
            if (result != null)
            {
                result.availability = "available";
                db.SaveChanges();
            }




            var result2 = db.Requests.SingleOrDefault(b => b.req_id == id);
            if (result2 != null)
            {
                
                result2.status = "Collected Successfully";
                db.SaveChanges();
            }


            return RedirectToAction("Employee_Dashboard");

        }
    }
}