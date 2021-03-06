﻿using InsuranceSecure.Models.Agents;
using InsuranceSecure.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace InsuranceSecure.Controllers
{
    public class DisplayAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public string City { get; set; }
        public string Pan { get; set; }
    }
    public class AgentsController : Controller
    {
        private AgentsEntities _db = new AgentsEntities();
        public static List<int> GetWorkingHours()
        {
            return new List<int>() { 9, 10, 11, 12, 13, 15, 16, 17 };
        }

        // GET: Agents
        [Route("Agents")]
        public ActionResult Index()
        {
            var model = _db.Agents.ToList();
            return View(model);
        }

        // GET: Agents
        [ActionName("All")]
        public ActionResult Agents()
        {
            var city = Request.QueryString["city"];
            var type = Request.QueryString["type"];
            //TODO: Query only type from database
            var agents = _db.Agents
                .Where(ag => ag.City.ToString() == city && ag.Type.ToLower() == type.ToLower())
                .ToList();
            var displayAgents = agents.Select(ag => new DisplayAgent()
            {
                Id = ag.Id,
                Name = $"{ag.FirstName} {ag.LastName}",
                Email = ag.Email,
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
        public bool BookAppointment(string user, string email, string contact, string dateTime)
        {
            var session = HttpContext.ApplicationInstance.Context.Session;
            var appointmentDate = DateTime.ParseExact(dateTime, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            var agentName = session["@User/AgentName"] != null ? session["@User/AgentName"].ToString() : "Rajeev Srivastava";
            var agentEmail = session["@User/AgentEmail"] != null && false? session["@User/AgentEmail"].ToString() : "";
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                try
                {
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("insurancesecure.mail@gmail.com", "insurance123$");
                    client.EnableSsl = true;

                    MailMessage usermail = new MailMessage();
                    string text = $"Hi {user}<br><br> Thank you for choosing InsuranceSecure for your insurance needs.<br>Our agent will contact you shortly. Please find below the details.<br><br>";
                    string html = Utilities.RenderPartialViewToString(this,
                        "EmailTemplates/UserAppointmentConfirmation",
                        Tuple.Create(agentName, appointmentDate.ToString("MMM dd, yyyy"), appointmentDate.ToShortTimeString()));

                    usermail.From = new MailAddress("insurancesecure.mail@gmail.com");
                    usermail.To.Add(!string.IsNullOrEmpty(email) ? email : "smita30apr@gmail.com");
                    usermail.Subject = "Appointment confirmation";
                    usermail.IsBodyHtml = true;
                    usermail.Body = text + html;
                    client.Send(usermail);

                    MailMessage agentmail = new MailMessage();
                    string agenttext = $"Hi {agentName}<br><br> New appointment details. Please contact the user ASAP.<br><br>";
                    string agenthtml = Utilities.RenderPartialViewToString(this,
                        "EmailTemplates/AppointmentConfirmation",
                        new AgentsEmailData()
                        {
                            UserName = user,
                            UserContact = contact,
                            UserEmail = email,
                            Date = appointmentDate.ToString("MMM dd, yyyy"),
                            Time = appointmentDate.ToShortTimeString()
                        });
                    agentmail.From = new MailAddress("insurancesecure.mail@gmail.com");
                    agentmail.To.Add(!string.IsNullOrEmpty(agentEmail) ? agentEmail : "sanjeev2675@gmail.com");
                    agentmail.Subject = "New Appointment Request";
                    agentmail.IsBodyHtml = true;
                    agentmail.Body = agenttext + agenthtml;
                    client.Send(agentmail);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return false;
                }
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return true;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Exclude = "Id")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                _db.Agents.Add(agent);
                _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(agent);
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
            var agentToEdit = (from m in _db.Agents

                               where m.Id == id

                               select m).First();

            return View(agentToEdit);
        }

        // POST: Agents/Edit/5
        [HttpPost]
        public ActionResult EditAgent(Agent agentToEdit)
        {
            try
            {
                if (!ModelState.IsValid)

                    return View();

                _db.Entry(agentToEdit).State = EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agent agent = _db.Agents.Find(id);
            if (agent == null)
            {
                return HttpNotFound();
            }
            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Agent agent = _db.Agents.Find(id);
                _db.Agents.Remove(agent);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
