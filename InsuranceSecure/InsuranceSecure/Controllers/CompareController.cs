using InsuranceSecure.ModelMappers;
using InsuranceSecure.Models.Insurance;
using InsuranceSecure.Models.User;
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
    public class CompareController : Controller
    {
        [HttpGet]
        [ActionName("CompareInsurance")]
        public ActionResult CompareInsurance()
        {
            var errorMessage = "";
            var status = new User().SaveDetails(Request.QueryString);
            errorMessage = !status ? "User Details cant be saved" : errorMessage;
            if (string.IsNullOrEmpty(errorMessage))
            {
                List<InsuranceData> insuranceData = new List<InsuranceData>()
                {
                    new InsuranceData("Reliance", "Reliance Cover", "Description to be added"),
                    new InsuranceData("Reliance", "Reliance Cover 1", "Description to be added"),
                    new InsuranceData("Tata IGI", "Tata Cover 2", "Description to be added"),
                    new InsuranceData("Inusrance 1", "Reliance Cover 2", "Description to be added"),
                    new InsuranceData("Insurance 2", "Reliance Cover 3", "Description to be added")
                };
                return View("Compare", insuranceData);
            }
            return Json(new
            {
                error = errorMessage
            });
        }

    }
}