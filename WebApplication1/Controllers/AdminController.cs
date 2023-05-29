using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.Models.DataContext;
using WebApplication1.Models.Model;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        ProjeDBContext db = new ProjeDBContext();
        // GET: Admin
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            var sorgu=db.Hakkimizda.ToList();
            return View(sorgu);
        }
        [Route("yonetimpaneli/giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(Admin admin,string sifre)
        {

            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            //sifre = Crypto.HashPassword(admin.Sifre);
            if (login != null && login.Eposta == admin.Eposta && /*Crypto.VerifyHashedPassword(login.Sifre, sifre)*/ login.Sifre == admin.Sifre)
            {
                // Giriş başarılı
                Session["adminid"] = login.AdminID;
                Session["eposta"] = login.Eposta;
                Session["yetki"] = login.Yetki;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı yada şifre yanlış";
            return View(admin);
        }
        public ActionResult Ayarlar()
        {
            var sorgu = db.Admin.ToList();
            return View(sorgu);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( Admin admin, string sifre, string eposta)
            
        {
            if (ModelState.IsValid)
            {
                admin.Sifre = Crypto.Hash(sifre,"MD5");
                admin.Eposta = eposta;
                db.Admin.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Ayarlar");
            }
            return View(admin);
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var sorgu = db.Admin.Where(x => x.AdminID == id).SingleOrDefault();
            if (sorgu == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Admin.Remove(sorgu);
                db.SaveChanges();
                return RedirectToAction("Ayarlar");
            }
         
        }
        public ActionResult Edit(int id)
        {
            var sorgu = db.Admin.Where(x => x.AdminID == id).SingleOrDefault();
            return View(sorgu);
        }
        [HttpPost]
        public ActionResult Edit(int id ,Admin admin, String sifre, string eposta)
        {
            
            if (ModelState.IsValid)
            {
                var sorgu = db.Admin.Where(x => x.AdminID == id).SingleOrDefault();
                sorgu.Sifre = Crypto.Hash(sifre, "MD5");
                sorgu.Eposta = eposta;
                sorgu.Yetki = admin.Yetki;
                db.SaveChanges();
                return RedirectToAction("Ayarlar");
            }
            return View(admin);
        }
          
        public ActionResult Logout()
        {
            Session["adminId"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifremiUnuttum(string eposta)
        {
            var mail = db.Admin.Where(x => x.Eposta == eposta).SingleOrDefault();
            if ( mail != null )
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();

                Admin admin=new Admin();
                mail.Sifre = Convert.ToString(yenisifre); 
                db.SaveChanges();
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "projewebdeneme@gmail.com";
                WebMail.Password = "pvuseygzxnmvokul";
                WebMail.Send(eposta,"Admin Paneli Sifreniz","Sifreniz"+yenisifre  );
                ViewBag.Mesaj = "Mesajınız başarıyla gönderilmiştir.";

            }
            else
            {
                ViewBag.Mesaj = "Lütfen tüm alanları doldurunuz.";
                return View();
            }
            return View();
        }
    }
}