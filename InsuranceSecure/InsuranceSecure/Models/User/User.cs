using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace InsuranceSecure.Models.User
{
    public class User
    {

        public bool SaveDetails(NameValueCollection queryString)
        {
            var session = HttpContext.Current.Session;
            var status = false;
            try
            {
                var insuranceType = queryString["insurance-type"];
                session["@User/InsuranceType"] = insuranceType;
                session["@User/PinCode"] = queryString["pincode"];
                session["@User/FirstName"] = queryString["firstname"];
                session["@User/LastName"] = queryString["lastname"];
                session["@User/Email"] = queryString["email"];
                session["@User/ContactNumber"] = queryString["contactnumber"];
                session["@User/DOB"] = queryString["dob"];
                var insurance = new object();
                switch (insuranceType.ToLower())
                {
                    case "life":
                        insurance = new { smokingstatus = queryString["smokingstatus"] };
                        break;
                    case "health":
                        break;
                    case "bike":
                    case "car":
                        insurance = new
                        {
                            make = queryString["make"],
                            registrationNumber = queryString["registrationnumber"],
                            registrationyear = queryString["registrationyear"],
                            policytype = queryString["policytype"]
                        };
                        break;
                    default:
                        break;
                }
                session["@User/InsuranceDetails"] = insurance;
                status = true;
            }
            catch
            {
                status = false;
            }

            return status;
                
        }

    }
}