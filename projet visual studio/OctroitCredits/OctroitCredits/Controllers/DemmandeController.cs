using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OctroitCredits.Models;
using OctroitCredits.Models.DemandeCredits;

namespace OctroitCredits.Controllers
{
    public class DemmandeController : Controller
    {
        DemandeCredits dbContext = new DemandeCredits();
        // GET: DemmandeController
        public ActionResult Index()
        {
            List<DemmandeModel> demandeList = dbContext.GetAllDemmande().ToList();
            return View(demandeList);
        }

        // GET: DemmandeController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            DemmandeModel demande = dbContext.GetDemmandeById(id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // GET: DemmandeController/Create
        public ActionResult Create()
        {
            List<ClientModel> listclient = dbContext.GetClient();
            SelectList selectLists = new SelectList(listclient, "Id", "Noms");
            ViewBag.listesclient = selectLists;
            return View();
        }

        // POST: DemmandeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] DemmandeModel demande)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateDemmande(demande);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(demande);
            }
        }

        // GET: DemmandeController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id <= 0)
            {
                return NotFound();
            }
            DemmandeModel demande = dbContext.GetDemmandeById(id);
            if (demande == null)
            {
                return NotFound();
            }
            return View(demande);
        }

        // POST: DemmandeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] DemmandeModel demande)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)

                {
                    dbContext.UpdateDemmande(demande);
                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: DemmandeController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
           DemmandeModel demande = dbContext.GetDemmandeById(id);
            if (demande == null)
            {
                return NotFound();
            }

            return View(demande);
        }

        // POST: DemmandeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                dbContext.DeleteDemmande(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
