﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace Test.MVCSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NLog.Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error("ERR");
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