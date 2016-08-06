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
    public class UserController : Controller
    {
        [HttpGet]
        [ActionName("SaveUserDetails")]
        public ActionResult SaveUserDetails()
        {
            var errorMessage = "";
            var status = new User().SaveDetails(Request.QueryString);
            errorMessage = !status ? "User Details cant be saved" : errorMessage;
            return Json(new
            {
                error = errorMessage
            });
        }

    }
}