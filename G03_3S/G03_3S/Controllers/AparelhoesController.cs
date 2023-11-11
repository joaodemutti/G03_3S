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
    public class AparelhoesController : Controller
    {
        private G03_3SEntities1 db = new G03_3SEntities1();

        // GET: Aparelhoes
        public ActionResult Index()
        {
            var aparelhoes = db.Aparelhoes.Include(a => a.Usuario);
            return View(aparelhoes.ToList());
        }

        // GET: Aparelhoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        // GET: Aparelhoes/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario");
            return View();
        }

        // POST: Aparelhoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAparelho,NomeAparelho,IdUsuario")] Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                db.Aparelhoes.Add(aparelho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", aparelho.IdUsuario);
            return View(aparelho);
        }

        // GET: Aparelhoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", aparelho.IdUsuario);
            return View(aparelho);
        }

        // POST: Aparelhoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAparelho,NomeAparelho,IdUsuario")] Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aparelho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", aparelho.IdUsuario);
            return View(aparelho);
        }

        // GET: Aparelhoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aparelho aparelho = db.Aparelhoes.Find(id);
            if (aparelho == null)
            {
                return HttpNotFound();
            }
            return View(aparelho);
        }

        // POST: Aparelhoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aparelho aparelho = db.Aparelhoes.Find(id);
            db.Aparelhoes.Remove(aparelho);
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
