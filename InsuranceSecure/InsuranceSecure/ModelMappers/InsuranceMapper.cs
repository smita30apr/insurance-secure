using InsuranceSecure.Models.Insurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceSecure.ModelMappers
{
    public static class InsuranceMapper
    {
        internal static Insurance FromType(string type)
        {
            Insurance insurance = null;
            switch (type)
            {
                case "life":
                case "child":
                case "term":
                case "retirement":
                case "ulip":
                    insurance = new Life();
                    break;
                case "car":
                case "bike":
                    insurance = new Vehicle();
                    break;
                case "health":
                    insurance = new Health();
                    break;
                default:
                    insurance = new Insurance();
                    break;
            }

            return insurance;
        }
    }
}