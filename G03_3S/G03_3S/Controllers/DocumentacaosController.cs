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
    public class DocumentacaosController : Controller
    {
        private G03_3SEntities1 db = new G03_3SEntities1();

        // GET: Documentacaos
        public ActionResult Index()
        {
            var documentacaos = db.Documentacaos.Include(d => d.Usuario);
            return View(documentacaos.ToList());
        }

        // GET: Documentacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentacao documentacao = db.Documentacaos.Find(id);
            if (documentacao == null)
            {
                return HttpNotFound();
            }
            return View(documentacao);
        }

        // GET: Documentacaos/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioAutor = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario");
            return View();
        }

        // POST: Documentacaos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumento,UsuarioAutor,Documento,NomeDocumento")] Documentacao documentacao)
        {
            if (ModelState.IsValid)
            {
                db.Documentacaos.Add(documentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioAutor = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", documentacao.UsuarioAutor);
            return View(documentacao);
        }

        // GET: Documentacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentacao documentacao = db.Documentacaos.Find(id);
            if (documentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioAutor = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", documentacao.UsuarioAutor);
            return View(documentacao);
        }

        // POST: Documentacaos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumento,UsuarioAutor,Documento,NomeDocumento")] Documentacao documentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioAutor = new SelectList(db.Usuarios, "IdUsuario", "NomeUsuario", documentacao.UsuarioAutor);
            return View(documentacao);
        }

        // GET: Documentacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documentacao documentacao = db.Documentacaos.Find(id);
            if (documentacao == null)
            {
                return HttpNotFound();
            }
            return View(documentacao);
        }

        // POST: Documentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documentacao documentacao = db.Documentacaos.Find(id);
            db.Documentacaos.Remove(documentacao);
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
