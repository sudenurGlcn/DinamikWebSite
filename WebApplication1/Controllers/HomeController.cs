using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Models.DataContext;
using WebApplication1.Models.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ProjeDBContext db = new ProjeDBContext();
        [Route("Anasayfa")]
        [Route("")]
        public ActionResult Index()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            return View();
        }
        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderID));
        }

        public ActionResult UrunlerPartial()
        {
            return View(db.Urunler.ToList().OrderByDescending(x => x.UrunId));
        }
        [Route("Hakkimizda")]
        public ActionResult Hakkimizda()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            //ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            return View(db.Hakkimizda.SingleOrDefault());
        }
        [Route("Urunlerimiz")]
        public ActionResult Urunlerimiz()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();

            return View(db.Urunler.ToList().OrderByDescending(x => x.UrunId));
        }
        [Route("Iletisim")]
        public ActionResult Iletisim()
        {
            ViewBag.Kimlik = db.Kimlik.SingleOrDefault();
            return View(db.Iletisim.SingleOrDefault());
        }
        [HttpPost]
        public ActionResult Iletisim(string adsoyad=null, string email=null, string konu=null, string mesaj=null )
        {
            if(adsoyad!=null && email!=null && konu!=null && mesaj!=null)
            {
               WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "projewebdeneme@gmail.com";
                WebMail.Password = "pvuseygzxnmvokul";
                WebMail.Send("projewebdeneme@gmail.com", konu,email +"</br>"+ mesaj);
                ViewBag.Mesaj = "Mesajınız başarıyla gönderilmiştir.";
               
            }
            else
            {
                ViewBag.Mesaj = "Lütfen tüm alanları doldurunuz.";
                return View();
            }   
            return View();
        }


        public ActionResult FooterPartial()
        {
            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();
            return PartialView();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}