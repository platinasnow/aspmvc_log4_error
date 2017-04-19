using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
   
    public class HomeController : Controller
    {
        //log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
                int x, y, z;
                x = 5; y = 0;
                z = x / y;
            return View();
        }

        public ActionResult Error500()
        {
        
            return View();
        }

        public ActionResult Error404()
        {

            return View();
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