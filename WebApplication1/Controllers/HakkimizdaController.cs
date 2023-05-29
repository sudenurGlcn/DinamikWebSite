using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DataContext;
using WebApplication1.Models.Model;

namespace WebApplication1.Controllers
{
    public class HakkimizdaController : Controller
    {
        ProjeDBContext db = new ProjeDBContext();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h= db.Hakkimizda.ToList();
            return View(h);
        }

       

        // GET: Hakkimizda/Edit/5
        public ActionResult Edit(int id)

        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaID == id).SingleOrDefault();
            return View(h);
        }

        // POST: Hakkimizda/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Hakkimizda h)
        {
         var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaID == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(h);
        }
        

       
    }
}
