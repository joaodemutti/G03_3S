using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using G03_3S;

namespace G03_3S.Controllers
{
    public class pontoesController : Controller
    {
        private G03_3SEntities1 db = new G03_3SEntities1();

        // GET: pontoes
        public ActionResult Index()
        {
            var pontoes = db.pontoes.Include(p => p.Usuario);
            return View(pontoes.ToList());
        }

        // GET: pontoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.pontoes.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // GET: pontoes/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuarioPonto = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario");
            return View();
        }

        // POST: pontoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuarioPonto,Hora")] ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.pontoes.Add(ponto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuarioPonto = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", ponto.IdUsuarioPonto);
            return View(ponto);
        }

        // GET: pontoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.pontoes.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuarioPonto = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", ponto.IdUsuarioPonto);
            return View(ponto);
        }

        // POST: pontoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuarioPonto,Hora")] ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuarioPonto = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", ponto.IdUsuarioPonto);
            return View(ponto);
        }

        // GET: pontoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.pontoes.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: pontoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponto ponto = db.pontoes.Find(id);
            db.pontoes.Remove(ponto);
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
