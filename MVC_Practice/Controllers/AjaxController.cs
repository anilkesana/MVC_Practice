using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Practice.Models;
using MVC_Practice.Data_Access;

namespace MVC_Practice.Controllers
{
    public class AjaxController : Controller
    {

        List<Product> Prolist = new List<Product>();
        DBContext db = new DBContext();


        // GET: /Ajax/


        public ActionResult Index()
        {
            //Product p1 = new Product { Prodcode = "P001", ProdName = "Mobile", ProdQty = 3 };
            //Product p2 = new Product { Prodcode = "P002", ProdName = "Laptop", ProdQty = 2 };
            //Product p3 = new Product { Prodcode = "P003", ProdName = "Tablet", ProdQty = 4 };
            //Prolist.Add(p1);
            //Prolist.Add(p2);
            //Prolist.Add(p3);
            //TempData["listdata"] = Prolist;
            return View();
        }

        [HttpPost]
        public PartialViewResult ShowDetails(string txtCode)
        {
            System.Threading.Thread.Sleep(3000);
            //string code = Request.Form["txtCode"];
            Product p1 = new Product { Prodcode = "P001", ProdName = "Mobile", ProdQty = 3 };
            Product p2 = new Product { Prodcode = "P002", ProdName = "Laptop", ProdQty = 2 };
            Product p3 = new Product { Prodcode = "P003", ProdName = "Tablet", ProdQty = 4 };
            Prolist.Add(p1);
            Prolist.Add(p2);
            Prolist.Add(p3);
            //var pname = Prolist.Select(x => x.ProdName).ToList();
            //SelectList list = new SelectList(Prolist, "Prodcode", "ProdName");
            Product pro = new Product();
            //var list = (List<Product>)TempData["listdata"];


            foreach (Product p in Prolist)
            {
                if (p.Prodcode == txtCode)
                {

                    pro = p;
                    break;
                }
            }


            return PartialView("_ShowDetails", pro);
        }

        public PartialViewResult allEmployees()
        {
            //List<Employee> emps = new List<Employee>();
            //Employee emp1 = new Employee() { EmployeeId = 001, EmployeeGender = "male", EmployeeName = "Ram", DepartmentId = 1 };
            //Employee emp2 = new Employee() { EmployeeId = 002, EmployeeGender = "female", EmployeeName = "Sita", DepartmentId = 2 };
            //emps.Add(emp1);
            //emps.Add(emp2);

            //Employee emp = new Employee();
            //if (emps.Count() != 0)
            //{
            //    var list = emps.Where(x => x.EmployeeId == 002).FirstOrDefault();
            //    emp = list;

            //}
            Employee empp = new Employee();
            var empslist = db.GetEmployees();
            foreach (Employee e in empslist)
            {

                empp = e;
                break;

            }


            return PartialView("_employees", empp);
        }

        public ActionResult Index2()
        {
            var empslist = db.GetEmployees();
            return View(empslist);
        }

        //
        // GET: /User/Details/5
        public ActionResult Details(int id = 0)
        {
            var empslist = db.GetEmployees();
            //User user = db.Users.Find(id);
            if (empslist != null)
            {
                foreach (var e in empslist)
                {

                    e.EmployeeId = id;
                    return View(e);

                }


            }
            return HttpNotFound();

        }
        //
        // GET: /User/Create

        public ActionResult Create()
        {

            return PartialView();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(Employee emp, string Command)
        {
            if (ModelState.IsValid)
            {
                db.SaveData(emp);
                TempData["Msg"] = "Data has been saved succeessfully";
                return RedirectToAction("Index2");
            }

            return View(emp);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var empslist = db.GetEmployees();
            //User user = db.Users.Find(id);

            foreach (var e in empslist)
            {
                if (e.EmployeeId == id)
                {
                    return View(e);
                }
            }
            return HttpNotFound();

        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.UpdateData(emp);
                TempData["Msg"] = "Data has been updated succeessfully";
                return RedirectToAction("Index2");
            }
            return View(emp);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {

            db.DeleteData(id);
            TempData["Msg"] = "Data has been deleted succeessfully";
            return RedirectToAction("Index2");
        }
        public ActionResult GetCountry()
        {

            List<string> Items = new List<string>();

            Items.Add("Please Select");
            Items.Add("India");
            Items.Add("USA");
            Items.Add("Pakistan");
            Items.Add("UK");

            SelectList countries = new SelectList(Items);

            ViewBag.country = countries;


            return View();
        }


        public JsonResult GetStates(string country)
        {
            List<string> states = new List<string>();

            switch (country)
            {
                case "India":
                    states.Add("AP");
                    states.Add("UP");
                    states.Add("MP");
                    states.Add("JK");
                    break;
                case "US":

                    states.Add("Washinton");
                    states.Add("Newyark");
                    states.Add("Cannada");
                    break;
                case "UK":
                    states.Add("London");
                    states.Add("Cambridge");
                    states.Add("Scotland");
                    break;
                case "Pakistan":
                    states.Add("Islamabad");
                    states.Add("Karachi");
                    states.Add("Peshawar");
                    break;
            }
            return Json(states);
        }

    }
}
