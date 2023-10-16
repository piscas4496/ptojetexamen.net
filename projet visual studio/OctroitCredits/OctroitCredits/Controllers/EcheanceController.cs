using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OctroitCredits.Models;
using OctroitCredits.Models.Echeances;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace OctroitCredits.Controllers
{
    public class EcheanceController : Controller
    {
        // GET: EcheanceController1
        Echeances dbContext = new Echeances();
        public ActionResult Index()
        {
            List<EcheanceModel> echeanceList = dbContext.GetAllEcheance().ToList();
            return View(echeanceList);
        }

        // GET: EcheanceController1/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            EcheanceModel echeance = dbContext.GetEcheanceById(id);
            if (echeance == null)
            {
                return NotFound();
            }

            return View(echeance);
        }

        // GET: EcheanceController1/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<ClientModel> listclient = dbContext.GetClient();
            SelectList selectLists = new SelectList(listclient, "Id","Noms");
            ViewBag.listesclient = selectLists;


            List<CreditModel> listcredit = dbContext.GetCredit();
            SelectList selectcredit = new SelectList(listcredit, "id", "relevespaie");
            ViewBag.listescredits = selectcredit;
            return View();
        }

        // POST: EcheanceController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] EcheanceModel echeance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.CreateEcheance(echeance);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(echeance);
            }
        }

        // GET: EcheanceController1/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            EcheanceModel echeance = dbContext.GetEcheanceById(id);
            if (echeance == null)
            {
                return NotFound();
            }
            return View(echeance);
        }

        // POST: EcheanceController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind] EcheanceModel echeance)
        {
            try
            {
                if (id <= 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)

                {
                    dbContext.UpdateEcheance(echeance);
                    return RedirectToAction("Index");
                }
                return View(dbContext);
            }
            catch
            {
                return View();
            }
        }

        // GET: EcheanceController1/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            EcheanceModel echeance = dbContext.GetEcheanceById(id);
            if (echeance == null)
            {
                return NotFound();
            }

            return View(echeance);
        }

        // POST: EcheanceController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                dbContext.DeleteEcheance(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
