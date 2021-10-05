using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROGETTO.DAL;
using PROGETTO.Models;

namespace PROGETTO.Controllers
{
    public class CommessaController : Controller
    {
        private Context db = new Context();

        // GET: Commessa
        //public ActionResult Index()
        //{
        //    var commessa = db.Commessa.Include(c => c.Cliente);
        //    return View(commessa.ToList());
        //}
        public ActionResult Index()
        {
            return View(db.Commessa.ToList());
        }
        // GET: Commessa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            return View(commessa);
        }

        // GET: Commessa/Create
        public ActionResult Create()
        {
            
            //ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale");
            PopulateClienteDropDownList();
            return View();
        }

        // POST: Commessa/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommessaID,Descrizione,ClienteID,DataInizio,DataFine,Importo")] Commessa commessa)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    db.Commessa.Add(commessa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            PopulateClienteDropDownList(commessa.ClienteID);
            return View(commessa);
        }

        // GET: Commessa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            PopulateClienteDropDownList(commessa.ClienteID);
            return View(commessa);
        }

        // POST: Commessa/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditCommessa(int? id)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(commessa).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            ////ViewBag.ClienteID = new SelectList(db.Cliente, "ClienteID", "RagioneSociale", commessa.ClienteID);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var commessaToUpdate = db.Commessa.Find(id);
            if (TryUpdateModel(commessaToUpdate, "",
               new string[] { "CommessaID", "Descrizione", "ClienteID", "DataInizio", "DataFine", "Importo" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateClienteDropDownList(commessaToUpdate.ClienteID);
                return View(commessaToUpdate);
        }

        // GET: Commessa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commessa commessa = db.Commessa.Find(id);
            if (commessa == null)
            {
                return HttpNotFound();
            }
            return View(commessa);
        }

        // POST: Commessa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commessa commessa = db.Commessa.Find(id);
            db.Commessa.Remove(commessa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateClienteDropDownList(object selectedCliente = null)
        {
            var clientesQuery = from d in db.Cliente
                                   orderby d.RagioneSociale
                                   select d;
            ViewBag.ClienteID = new SelectList(clientesQuery, "ClienteID", "RagioneSociale", selectedCliente);
        }
    }
}
