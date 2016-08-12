using InsuranceSecure.Models.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace InsuranceSecure.Controllers
{
    public class DisplayAgent
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public string City { get; set; }
    }
    public class AgentsController : Controller
    {
        public static List<int> GetWorkingHours()
        {
            return new List<int>() { 9, 10, 11, 12, 13, 15, 16, 17 };
        }

        // GET: Agents
        [Route("Agents")]
        public ActionResult Index()
        {
            AgentsEntities _db = new AgentsEntities();
            var model = _db.Agents.ToList();
            return View(model);
        }

        // GET: Agents
        [ActionName("All")]
        public ActionResult Agents()
        {
            var pin = Request.QueryString["pin"];
            var type = Request.QueryString["type"];
            AgentsEntities _db = new AgentsEntities();
            //TODO: Query only type from database
            var agents = _db.Agents
                .Where(ag => ag.Pin.ToString() == pin && ag.Type.ToLower() == type.ToLower())
                .ToList();
            var displayAgents = agents.Select(ag => new DisplayAgent()
            {
                Name = $"{ag.FirstName} {ag.LastName}",
                Address = ag.Address,
                Pin = ag.Pin.ToString(),
                City = ag.City
            }).ToList();

            return View("AgentsUserView", displayAgents);
        }

        [HttpGet]
        public ActionResult WorkingHours(string date)
        {
            //TODO: take individual agents working hours
            DateTime dateSelected = Convert.ToDateTime(date);
            if (DateTime.Now < dateSelected)
                return PartialView("TimeSlots", GetWorkingHours());
            return PartialView("TimeSlots", GetWorkingHours().Where(w => w > DateTime.Now.Hour + 1).ToList());
        }

        [HttpGet]
        [Route("Agents/BookAppointment")]
        public ActionResult BookAppointment(/*string url*/)
        {
            var dateTime = "2014-1-11";
            var appointmentDate = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH-mm-ss", System.Globalization.CultureInfo.InvariantCulture);
            using (var client = new SmtpClient())
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("insurancesecure.mail@gmail.com");
                    mail.To.Add("smita30apr@gmail.com");
                    mail.Subject = "Test Mail";
                    mail.Body = "This is for testing SMTP mail from GMAIL";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("insurancesecure.mail@gmail.com", "insurance123$");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    var x = 1;
                    //MessageBox.Show(ex.ToString());
                }
            }
            return Json(new { name ="s"});
        }

        // GET: Agents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agents/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agents/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
