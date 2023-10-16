using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OctroitCredits.Models;
using OctroitCredits.Models.Comptes;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OctroitCredits.Controllers
{
    
    public class CompteController : Controller
    {
        // GET: CompteController
        Comptes dbContext = new Comptes();
        public ActionResult Index()
        {
            List<CompteModel>compteList = dbContext.GetAllCompte().ToList();
            return View(compteList);
        }

        // GET: CompteController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CompteModel compte = dbContext.GetCompteById(id);
            if (compte == null)
            {
                return NotFound();
            }

            return View(compte);
        }

        // GET: CompteController/Create
        public ActionResult Create()
        {
            List<ClientModel> listclient = dbContext.GetClient();
            SelectList selectLists = new SelectList(listclient, "Id", "Noms");
            ViewBag.listesclient = selectLists;

            return View();
        }

        // POST: CompteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] CompteModel compte)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateCompte(compte);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(compte);
            }
        }

        // GET: CompteController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CompteModel compte = dbContext.GetCompteById(id);
            if (compte == null)
            {
                return NotFound();
            }

            return View(compte);
        }

        // POST: CompteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] CompteModel compte)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }
                if (compte == null)
                {
                    return NotFound();
                }

                return View(compte);
            }
            catch
            {
                return View();
            }
        }

        // GET: CompteController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CompteModel compte = dbContext.GetCompteById(id);
            if (compte == null)
            {
                return NotFound();
            }

            return View(compte);
        }

        // POST: CompteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deleteconfirm(int id, IFormCollection collection)
        {
            try
            {
                dbContext.DeleteCompte(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
