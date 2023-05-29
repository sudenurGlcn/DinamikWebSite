using WebApplication1.Models.DataContext;
using WebApplication1.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WepApplication1.Controllers
{
    public class UrunlerController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();
        // GET: Urunler
        public ActionResult Index()
        {
            return View(db.Urunler.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Urunler urunler, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Urunler/" + logoname);

                    urunler.ResimURL = "/Uploads/Urunler/" + logoname;
                }
                db.Urunler.Add(urunler);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(urunler);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Uyari = "Güncellenecek Urunler Bulunamadı";
            }
            var urunler = db.Urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }

            return View(urunler);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, Urunler urunler, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var h = db.Urunler.Where(x => x.UrunId == id).SingleOrDefault();
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string Urunlername = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Urunler/" + Urunlername);

                    h.ResimURL = "/Uploads/Urunler/" + Urunlername;
                }

                h.Baslik = urunler.Baslik;
                h.Aciklama = urunler.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var h = db.Urunler.Find(id);
            if (h == null)
            {
                return HttpNotFound();
            }
            db.Urunler.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}