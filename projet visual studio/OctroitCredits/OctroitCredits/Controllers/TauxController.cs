using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using OctroitCredits.Models;

namespace OctroitCredits.Controllers
{
    public class TauxController : Controller
    {
        readonly Taux taux = new Taux();

        // GET: TauxController
        public ActionResult Index()
        {
            List<TauxModel> listTaux = taux.GetAllTaux().ToList();
            return View(listTaux);
        }

        // GET: TauxController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            TauxModel tauxto = taux.GetTauxById(id);
            if (tauxto == null)
            {
                return NotFound();
            }
            return View(tauxto);
        }

        // GET: TauxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TauxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] TauxModel tauxTo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    taux.CreateTaux(tauxTo);
                    return RedirectToAction("Index");
                }
                return View(tauxTo);
            }
            catch
            {
                return View();
            }
        }

        // GET: TauxController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            TauxModel tauxTo = taux.GetTauxById(id);
            if (tauxTo == null)
            {
                return NotFound();
            }
            return View(tauxTo);
        }

        // POST: TauxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] TauxModel tauxTo)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    taux.UpdateTaux(tauxTo);
                    return RedirectToAction("Index");
                }
                return View(taux);
            }
            catch
            {
                return View();
            }
        }

        // GET: TauxController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            TauxModel tauxTo = taux.GetTauxById(id);
            if (tauxTo == null)
            {
                return NotFound();
            }
            return View(tauxTo);
        }

        // POST: TauxController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                taux.DeleteTaux(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
