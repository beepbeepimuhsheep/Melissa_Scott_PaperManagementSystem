﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Melissa_Scott_9189_SA2_IPG521_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult News()
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