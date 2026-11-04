using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ogrenci_Not_Mvc.Models.EntityFremework;

namespace Ogrenci_Not_Mvc.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Karsilama()
        {
            return View("Karsilama");
        }


        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TblOgrenciler p)
        {
            using (var db = new Models.EntityFremework.DbMvcOkulEntities2())
            {
                var bilgiler = db.TblOgrenciler.FirstOrDefault(x => x.OgrenciAd == p.OgrenciAd && x.Sifre == p.Sifre);
                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.OgrenciAd, false);
                    Session["OgrenciAd"] = bilgiler.OgrenciAd.ToString();
                    return RedirectToAction("ogrenc", "Ogrenciler");
                }
                else
                {
                    ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
                    return View("GirisYap");
                }
            }
        }
    }
}