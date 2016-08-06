using InsuranceSecure.Models.Agents;
using System.Linq;
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
