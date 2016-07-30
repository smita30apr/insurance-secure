﻿using InsuranceSecure.ModelMappers;
using InsuranceSecure.Models.Insurance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSecure.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect(Url.Content("~/home/insurance?type=life"));
        }

        [ActionName("Insurance")]
        public ActionResult Insurance(string type)
        {
            Insurance insurance = InsuranceMapper.FromType(type);
            PropertyInfo[] properties = insurance.GetType().GetProperties();

            return View("Insurance", insurance);
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