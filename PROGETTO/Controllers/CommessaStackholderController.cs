﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROGETTO.DAL;
using PROGETTO.Models;

namespace PROGETTO.Controllers
{
    public class CommessaStackholderController : Controller
    {
        private Context db = new Context();

        // GET: CommessaStackholder
        public ActionResult Index()
        {
            var commessaStackholders = db.CommessaStackholders.Include(c => c.Commessa).Include(c => c.Stackholder);
            return View(commessaStackholders.ToList());
        }

        // GET: CommessaStackholder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Create
        public ActionResult Create()
        {
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "CommessaID");
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "StackholderID");
            return View();
        }

        // POST: CommessaStackholder/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroRilevamentoID,CommessaID,StackholderID,DataRilevamento,Potere,Interesse,Impatto,Note")] CommessaStackholder commessaStackholder)
        {
            if (ModelState.IsValid)
            {
                db.CommessaStackholders.Add(commessaStackholder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // POST: CommessaStackholder/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroRilevamentoID,CommessaID,StackholderID,DataRilevamento,Potere,Interesse,Impatto,Note")] CommessaStackholder commessaStackholder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commessaStackholder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommessaID = new SelectList(db.Commessa, "CommessaID", "Descrizione", commessaStackholder.CommessaID);
            ViewBag.StackholderID = new SelectList(db.Stackholder, "StackholderID", "Nome", commessaStackholder.StackholderID);
            return View(commessaStackholder);
        }

        // GET: CommessaStackholder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            if (commessaStackholder == null)
            {
                return HttpNotFound();
            }
            return View(commessaStackholder);
        }

        // POST: CommessaStackholder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommessaStackholder commessaStackholder = db.CommessaStackholders.Find(id);
            db.CommessaStackholders.Remove(commessaStackholder);
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
    }
}
