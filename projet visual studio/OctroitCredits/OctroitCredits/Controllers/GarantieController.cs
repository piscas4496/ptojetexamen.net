using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using OctroitCredits.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OctroitCredits.Controllers
{
    public class GarantieController : Controller
    {
         Garantie garantie = new Garantie();

        // GET: GarantieController
        public ActionResult Index()
        {
            List<GarantieModel> listGarantie = garantie.GetAllGarantie().ToList();
            return View(listGarantie);
        }

        // GET: GarantieController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            GarantieModel garanties = garantie.GetGarantieById(id);
            if (garanties == null)
            {
                return NotFound();
            }
            return View(garanties);
        }

        // GET: GarantieController/Create
        public ActionResult Create()
        {
            List<ClientModel> listclient = garantie.GetClient();
            SelectList selectLists = new SelectList(listclient, "Id", "Noms");
            ViewBag.listesclient = selectLists;

            List<CompteModel> compteList = garantie.GetCompte();
            SelectList selectList = new SelectList(compteList, "id", "numCompte");
            ViewBag.listescompte = selectList;
            return View();
           
        }

        // POST: GarantieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] GarantieModel garanties)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    garantie.CreateGarantie(garanties);
                    return RedirectToAction("Index");
                }
                return View(garanties);
            }
            catch
            {
                return View();
            }
        }

        // GET: GarantieController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            GarantieModel garanties = garantie.GetGarantieById(id);
            if (garanties == null)
            {
                return NotFound();
            }
            return View(garanties);
        }

        // POST: GarantieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] GarantieModel garanties)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    garantie.UpdateGarantie(garanties);
                    return RedirectToAction("Index");
                }
                return View(garantie);
            }
            catch
            {
                return View();
            }
        }

        // GET: GarantieController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            GarantieModel garanties = garantie.GetGarantieById(id);
            if (garanties == null)
            {
                return NotFound();
            }
            return View(garanties);
        }

        // POST: GarantieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                garantie.DeleteGarantie(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
