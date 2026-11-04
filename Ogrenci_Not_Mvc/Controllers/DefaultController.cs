using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci_Not_Mvc.Models.EntityFremework;


namespace Ogrenci_Not_Mvc.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var dersler = db.TblDersler.ToList();
            return View("Index", dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TblDersler p)
        {
            db.TblDersler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DersSıl(int id)
        {
            var drs = db.TblDersler.Find(id);

            var ogrenciler = db.TblNotlar.Where(x => x.DersId == id).ToList();

            db.TblDersler.Remove(drs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult dersgetir(int id)
        {
            var drs = db.TblDersler.Find(id);
            return View("dersgüncelleme", drs);
        }
        public ActionResult dersgüncelleme(TblDersler p)
        {
            var drs = db.TblDersler.Find(p.DersId);

            if (drs != null)
            {
                drs.DersAd = p.DersAd;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Iletisim()
        {
            ViewBag.ToplamOgrenci = db.TblOgrenciler.Count();
            ViewBag.ToplamDers = db.TblDersler.Count();
            ViewBag.ToplamKulup = db.TblKulupler.Count();
            ViewBag.KalanOgrenci = db.TblNotlar.Where(x => x.Durum == false).Count();
            ViewBag.GecenOgrenci = db.TblNotlar.Where(x => x.Durum == true).Count();

            return View();
        }
    }
}