using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ogrenci_Not_Mvc.Models.EntityFremework;
using System.Data.Entity;

namespace Ogrenci_Not_Mvc.Controllers
{
    [Authorize]
    public class SınavlarController : Controller
    {
        // GET: Sınavlar
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult Index()
        {
            var sınavlar = db.TblNotlar.Include(m => m.TblOgrenciler).Include(m => m.TblDersler).ToList();
            return View(sınavlar);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            // Öğrencileri Ad ve Soyad birleşik şekilde listeye alıyoruz
            List<SelectListItem> ogrenciler = (from x in db.TblOgrenciler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.OgrenciAd + " " + x.OgrenciSoyad, // Ekranda Ad Soyad görünecek
                                                   Value = x.OgrenciID.ToString()             // Arka planda ID'si tutulacak
                                               }).ToList();
            ViewBag.OgrList = ogrenciler;

            // Dersleri listeye alıyoruz
            List<SelectListItem> dersler = (from x in db.TblDersler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DersAd,                   // Ekranda Ders Adı görünecek
                                                Value = x.DersId.ToString()        // Arka planda ID'si tutulacak
                                            }).ToList();
            ViewBag.DersList = dersler;

            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TblNotlar p)
        {
            db.TblNotlar.Add(p);

            p.Sınav1 = p.Sınav1;
            p.Sınav2 = p.Sınav2;
            p.Sınav3 = p.Sınav3;
            p.Proje = p.Proje;
            p.Ortalama = (p.Sınav1 + p.Sınav2 + p.Sınav3 + p.Proje) / 4;


            if (p.Ortalama >= 50)
            {
                p.Durum = true;
            }
            else
            {
                p.Durum = false;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotSil(int id)
        {
            var not = db.TblNotlar.Find(id);

            if (not != null)
            {
                db.TblNotlar.Remove(not);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NotGetir(int id)
        {
            var not = db.TblNotlar.Find(id);
            return View("NotGetir", not);
        }
        [HttpPost]
        public ActionResult NotGuncelle(TblNotlar p)
        {
            var not = db.TblNotlar.Find(p.NotId);      
            
                not.Sınav1 = p.Sınav1;
                not.Sınav2 = p.Sınav2;
                not.Sınav3 = p.Sınav3;
                not.Proje = p.Proje;
                not.Ortalama = (p.Sınav1 + p.Sınav2 + p.Sınav3 + p.Proje) / 4;

            if (not.Ortalama >= 50)
            {
                not.Durum = true;
            }
            else
            {
                not.Durum = false;
            }
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}