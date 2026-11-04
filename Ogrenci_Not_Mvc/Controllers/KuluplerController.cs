using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci_Not_Mvc.Models.EntityFremework;

namespace Ogrenci_Not_Mvc.Controllers
{
    [Authorize]
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var kulupler = db.TblKulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TblKulupler p)
        {
            
            db.TblKulupler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sıl(int id)
        {
            var Kulup = db.TblKulupler.Find(id);
            db.TblKulupler.Remove(Kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetirKlüp(int id)
        {
            var klp = db.TblKulupler.Find(id);


            return View("GetirKlüp", klp);

        }
        public ActionResult Güncelle(TblKulupler p)
        {
            var klp = db.TblKulupler.Find(p.KulupId);
            klp.KulupAD = p.KulupAD;
            klp.KulupKontenjan = p.KulupKontenjan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}