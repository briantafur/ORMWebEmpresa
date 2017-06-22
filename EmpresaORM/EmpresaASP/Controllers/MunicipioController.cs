using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Entity;

namespace EmpresaASP.Controllers
{
    public class MunicipioController : Controller
    {
        private ejemploEmpresaEntities db = new ejemploEmpresaEntities();

        // GET: Municipio
        public ActionResult Index()
        {
            var municipio = db.municipio.Include(m => m.departamento);
            return View(municipio.ToList());
        }

        // GET: Municipio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipio municipio = db.municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // GET: Municipio/Create
        public ActionResult Create()
        {
            ViewBag.idDepartamento = new SelectList(db.departamento, "id", "nombre");
            return View();
        }

        // POST: Municipio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idDepartamento,nombre,descripcion")] municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.municipio.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDepartamento = new SelectList(db.departamento, "id", "nombre", municipio.idDepartamento);
            return View(municipio);
        }

        // GET: Municipio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipio municipio = db.municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartamento = new SelectList(db.departamento, "id", "nombre", municipio.idDepartamento);
            return View(municipio);
        }

        // POST: Municipio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idDepartamento,nombre,descripcion")] municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartamento = new SelectList(db.departamento, "id", "nombre", municipio.idDepartamento);
            return View(municipio);
        }

        // GET: Municipio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            municipio municipio = db.municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: Municipio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            municipio municipio = db.municipio.Find(id);
            db.municipio.Remove(municipio);
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
