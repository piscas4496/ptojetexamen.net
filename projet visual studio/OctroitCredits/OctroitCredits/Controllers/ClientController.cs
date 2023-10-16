using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class ClientsController : Controller
    {
        readonly Clients cl = new Clients();

        // GET: ClientsController
        public ActionResult Index()
        {
            List<ClientModel> listCLient = cl.GetAllClients().ToList();
            return View(listCLient);
        }

        // GET: ClientsController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            ClientModel client = cl.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] ClientModel client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cl.CreateClient(client);
                    return RedirectToAction("Index");
                }
                return View(client);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            ClientModel client = cl.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] ClientModel client)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    cl.UpdateClient(client);
                    return RedirectToAction("Index");
                }
                return View(cl);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            ClientModel client = cl.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
            //return View(client);
        }

        // POST: ClientsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                cl.DeleteClient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
