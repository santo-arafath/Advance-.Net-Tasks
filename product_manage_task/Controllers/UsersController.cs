using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using product_manage_task.EF;

namespace product_manage_task.Controllers
{
    public class UsersController : Controller
    {

        int[] card=new int[20];
        List<Product> products = new List<Product>();
        int cnt = 0;
        



        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult login()
        {
            Session["cnt"] = cnt;
            Session["card"] = card;
            Session["user"] =null;
            Session["id"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string username = fc["username"];
            string password = fc["password"];

            var db = new product_management_dbEntities();

            var user = (from s in db.Customers
                        where s.username == username && s.password == password
                        select s).FirstOrDefault();

            if (user != null)
            {
                Session["user"] = username;
                Session["id"] = user.id;
               return RedirectToAction("Category");
            }
            else
            {
                
                Session["user"] = "Wrong password";
                return View();
            }
        }



        public ActionResult Category()
        {
            var db = new product_management_dbEntities();
            var user = db.Categories.ToList();
            return View(user);
        }


        public ActionResult Details(int id)
        {
            var db=new product_management_dbEntities();
            var product = (from s in db.Products
                        where s.category_id == id
                        select s).ToList();
            return View(product);
        }

       
        

        public ActionResult Add_to_card(int id)
        {
            

            int cunt = Convert.ToInt32(Session["cnt"]);
            int[] cardd = Session["Card"] as int[];

            cardd[cunt] = id;
            cunt=cunt+1;
            Session["cnt"]=cunt;
            Session["card"] = cardd;


            /*foreach (int idd in cardd)
            {
                Debug.WriteLine("Added product ---: " + idd);
            }

            Debug.WriteLine("size  ---: " + cardd.Length);


            Debug.WriteLine("Added product ID: " + id);
            Debug.WriteLine("Card cnt: " +  cunt);*/

           var db = new product_management_dbEntities();
            

            foreach (int productId in cardd)
            {
                var product = (from s in db.Products
                               where s.pid == productId
                               select s).FirstOrDefault();

                if (product != null)
                {
                    products.Add(product);
                }
            }

            return View(products);
        }






        public ActionResult Order(int id)
        {
            Session["msg"] = null;
            var db = new product_management_dbEntities();
            var order = new Order_table
            {
                pid = id,
                uid = Convert.ToInt32(Session["id"])
            };

            
            db.Order_table.Add(order);

            
            db.SaveChanges();


            int[] card_del = Session["Card"] as int[];

            for (int i=0;i< card_del.Length;i++)
            {
                if (card_del[i] == id)
                {
                    card_del[i] = 0;
                    continue;
                }
            }


            return RedirectToAction("Add_to_card", new { id = 0 });
        }




        public ActionResult order_all()
        {



            var db = new product_management_dbEntities();

            int[] card_del = Session["Card"] as int[];

            for (int i = 0; i < card_del.Length; i++)
            {
                if (card_del[i] != 0)
                {

                    int in_id = card_del[i];
                    var order = new Order_table
                    {
                        pid = in_id,
                        uid = Convert.ToInt32(Session["id"])
                    };

                    db.Order_table.Add(order);
                    db.SaveChanges();

                    card_del[i] = 0;

                }

            }

            Session["msg"] = "Ordered Successfully !";
            return RedirectToAction("Add_to_card", new { id = 0 });


        }





    }
}