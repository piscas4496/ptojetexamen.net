using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OctroitCredits.Models;
using System.Data;
using OctroitCredits.Models.Credits;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OctroitCredits.Controllers
{
    public class CreditController : Controller
    {
        // GET: CreditController1
        Credits dbContext = new Credits();
        public ActionResult Index()
        {
            List<CreditModel> creditList = dbContext.GetAllCredits().ToList();
            return View(creditList);
        }

        // GET: CreditController1/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CreditModel credit = dbContext.GetCreditById(id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: CreditController1/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<ClientModel> listclient = dbContext.GetClient();
            SelectList selectLists = new SelectList(listclient, "Id", "Noms");
            ViewBag.listesclient = selectLists;

            List<CompteModel>compteList = dbContext.GetCompte();
            SelectList selectList = new SelectList(compteList, "id", "numCompte");
            ViewBag.listescompte = selectList;
            return View();
        }

        // POST: CreditController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] CreditModel credit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateCredit(credit);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(credit);
            }
        }

        // GET: CreditController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CreditModel credit = dbContext.GetCreditById(id);
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: CreditController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] CreditModel credit)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)

                {
                    dbContext.UpdateCredit(credit);
                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditController1/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            CreditModel credit = dbContext.GetCreditById(id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // POST: CreditController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmDelete(int id)
        {
            try
            {
                dbContext.DeleteCredit(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
