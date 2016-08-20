using InsuranceSecure.ModelMappers;
using InsuranceSecure.Models.Insurance;
using InsuranceSecure.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSecure.Controllers
{
    public class CompareController : Controller
    {
        //private string GetImageName(string type)
        //{
        //    switch (type.ToLower())
        //    {
        //        case "reliance":
        //            return "reliance.png";
        //        case "tata aia":
        //            return "tata-aia-life.png";
        //        case "birla":
        //            return "birla.png";
        //    }
        //    return "";
        //}

        //private string GetBrochureName(string type)
        //{
        //    switch (type.ToLower())
        //    {
        //        case "reliance":
        //            return "Reliance.pdf";
        //        case "tata aia":
        //            return "tata-aia.pdf";
        //        case "birla":
        //            return "irla.png";
        //    }
        //    return "";
        //}

        [HttpGet]
        [ActionName("CompareInsurance")]
        public ActionResult CompareInsurance()
        {
            var errorMessage = "";
            var status = new User().SaveDetails(Request.QueryString);
            errorMessage = !status ? "User Details cant be saved" : errorMessage;
            if (string.IsNullOrEmpty(errorMessage))
            {
                List<InsuranceData> insuranceData = new List<InsuranceData>();
                var stream = GetType().Assembly.GetManifestResourceStream("InsuranceSecure.App_Data.LifeInsurance.txt");
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var insurance = line.Split(':');
                            insuranceData.Add(new InsuranceData()
                            {
                                Type = insurance[1],
                                Heading = insurance[2],
                                CoverTill = insurance[3],
                                TotalPayout = insurance[4],
                                Premium = insurance[5],
                                ImageUrl = insurance[6],
                                Brochure = insurance[7]
                            });
                        }
                    }
                }
                return View("Compare", insuranceData);
            }
            return Json(new
            {
                error = errorMessage
            });
        }

    }
}