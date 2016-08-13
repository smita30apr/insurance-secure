using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSecure.Models.Utilities
{
    public class Utilities
    {
        public static string RenderPartialViewToString(Controller controller, string viewName, object model = null)
        {
            controller.ViewData.Model = model;
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);

                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }

    public class AgentsEmailData
    {
        public string UserName { get; set; }
        public string UserContact { get; set; }
        public string UserEmail { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}