using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class EvenementController : Controller
    {
        readonly EvenementPaie evenement = new EvenementPaie();

        // GET: EvenementController
        public ActionResult Index()
        {
            List<EvenementModel> listEvenement = evenement.GetAllEvenement().ToList();
            return View(listEvenement);
        }

        // GET: EvenementController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            EvenementModel evenements = evenement.GetEvenementById(id);
            if (evenements == null)
            {
                return NotFound();
            }
            return View(evenements);
        }

        // GET: EvenementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EvenementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] EvenementModel evenements)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    evenement.CreateEvenement(evenements);
                    return RedirectToAction("Index");
                }
                return View(evenements);
            }
            catch
            {
                return View();
            }
        }

        // GET: EvenementController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            EvenementModel evenements = evenement.GetEvenementById(id);
            if (evenements == null)
            {
                return NotFound();
            }
            return View(evenements);
        }

        // POST: EvenementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EvenementModel evenements)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    evenement.UpdateEvenement(evenements);
                    return RedirectToAction("Index");
                }
                return View(evenement);
            }
            catch
            {
                return View();
            }
        }

        // GET: EvenementController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            EvenementModel evenements = evenement.GetEvenementById(id);
            if (evenements == null)
            {
                return NotFound();
            }
            return View(evenements);
        }

        // POST: EvenementController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                evenement.DeleteEvenement(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
