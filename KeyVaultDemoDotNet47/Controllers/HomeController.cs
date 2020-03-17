﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeyVaultDemoDotNet47.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
         
            ViewBag.Message = "Value from Key Valut => " + ConfigurationManager.AppSettings["mysecret"];
            ViewBag.ConnectionString = $" Value from Key Valut ==> { ConfigurationManager.ConnectionStrings["DefaultDbConnestionString"]}";
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