using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace Test.MVCSite.Controllers
{
    public class HomeController : Controller
    {
        static NLog.Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
           
            logger.Error("test ouput");
            logger.Info("test ouput");
            
            try
            {
                System.IO.File.Open("tata",FileMode.Open);
            }
            catch (Exception e)
            {
                logger.ErrorException("err msg", e);
            }
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