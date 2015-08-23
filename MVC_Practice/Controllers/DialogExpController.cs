using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Practice.Controllers
{
    public class DialogExpController : Controller
    {
        //
        // GET: /DialogExp/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /DialogExp/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DialogExp/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
