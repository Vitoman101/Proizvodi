using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Proizvodi.Data;
using Proizvodi.Models;

namespace Proizvodi.Controllers
{
    public class ProizvodsController : Controller
    {
        private ProizvodiContext db = new ProizvodiContext();

        // GET: Proizvods
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Proizvods.ToList());
        }

        [HttpPost]
        public ActionResult Index(Proizvod obj)
        { 
            var proizvodlist = db.Proizvods.ToList();
            string jsondata = new JavaScriptSerializer().Serialize(proizvodlist);
            string path = Server.MapPath("~/App_Data/");  
            System.IO.File.WriteAllText(path + "output.json", jsondata);
            TempData["msg"] = "Json Generisan";
            return RedirectToAction("Index"); ;
        }

        // GET: Proizvods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: Proizvods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Proizvods.Add(proizvod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proizvod);
        }

        // GET: Proizvods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proizvod);
        }

        // GET: Proizvods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proizvod proizvod = db.Proizvods.Find(id);
            db.Proizvods.Remove(proizvod);
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
