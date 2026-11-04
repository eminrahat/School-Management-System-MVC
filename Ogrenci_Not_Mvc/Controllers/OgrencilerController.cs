using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CustomUI;
using Ogrenci_Not_Mvc.Models.EntityFremework;
using PagedList;
using PagedList.Mvc;

namespace Ogrenci_Not_Mvc.Controllers
{
    [Authorize]
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities2 db = new DbMvcOkulEntities2();
        public ActionResult ogrenc(string p, int sayfa = 1)
        {
            // Veritabanındaki tüm öğrencileri al (Süzgeç hazırlığı)
            var ogrenciler = from d in db.TblOgrenciler select d;

            // Eğer arama kutusu doluysa (örn: Hakan yazılmışsa) süzgeci daralt
            if (!string.IsNullOrEmpty(p))
            {
                ogrenciler = ogrenciler.Where(m => m.OgrenciAd.Contains(p));
            }

            // İster tüm liste olsun, ister süzülmüş liste olsun; 10'arlı kes ve sayfaya yolla!
            return View(ogrenciler.ToList().ToPagedList(sayfa, 10));
        }

        [HttpGet]
        public ActionResult OgrenciEkleme()
        {
            List<SelectListItem> degerler = (from i in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KulupAD,
                                                 Value = i.KulupId.ToString(),
                                             }).ToList();
            ViewBag.Dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkleme(TblOgrenciler p)
        {
            var klp = db.TblKulupler.Where(m => m.KulupId == p.TblKulupler.KulupId).FirstOrDefault();
            p.TblKulupler = klp;
            db.TblOgrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("ogrenc");
        }

        public ActionResult OgrenciSil(int id)
        {

            var Ogr = db.TblOgrenciler.Find(id);

            var notlar = db.TblNotlar.Where(x => x.OgrenciId == id).ToList();
            db.TblNotlar.RemoveRange(notlar);

            db.TblOgrenciler.Remove(Ogr);
            db.SaveChanges();
            return RedirectToAction("Ogrenc");
        }
        [HttpGet]
        public ActionResult GetirOgrenci(int id)
        {
            // Kulüpleri veritabanından çekip Text (Görünen Ad) ve Value (Arkadaki ID) olarak ayarlıyoruz
            List<SelectListItem> kulupListesi = (from i in db.TblKulupler.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KulupAD,
                                                     Value = i.KulupId.ToString()
                                                 }).ToList();

            // Bu listeyi View'da yakalamak için ViewBag içine atıyoruz
            ViewBag.Klb = kulupListesi;



            List<SelectListItem> cinsiyetListesi = new List<SelectListItem>
            {
                new SelectListItem { Text = "Erkek", Value = "Erkek" },
                new SelectListItem { Text = "Kadın", Value = "Kadın" }
            };
            ViewBag.Cinsiyet = cinsiyetListesi;


            var Ogrenciler = db.TblOgrenciler.Find(id);
            return View("ogrgüncelleme", Ogrenciler);
        }
        [HttpPost] // <-- Bu tag'i kesin ekle
        public ActionResult OgrenciGuncelle(TblOgrenciler p)
        {
            var ogr = db.TblOgrenciler.Find(p.OgrenciID);

            // Veritabanından gerçekten bir kayıt geldiyse güncelleme yap
            if (ogr != null)
            {
                ogr.OgrenciAd = p.OgrenciAd;
                ogr.OgrenciSoyad = p.OgrenciSoyad;
                ogr.OgrenciKulup = p.OgrenciKulup;
                ogr.OgrenciCinsiyet = p.OgrenciCinsiyet;
                db.SaveChanges();
            }

            // View adının "ogrenc" olduğundan emin ol (genelde Ogrenci veya Index olur)
            return RedirectToAction("ogrenc");
        }
        public ActionResult ExcelIndir()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Öğrenci Listesi");

                worksheet.Cell(1, 1).Value = "Öğrenci Adı";
                worksheet.Cell(1, 2).Value = "Soyadı";
                worksheet.Cell(1, 3).Value = "Ders";
                worksheet.Cell(1, 4).Value = "Sınav 1";
                worksheet.Cell(1, 5).Value = "Sınav 2";
                worksheet.Cell(1, 6).Value = "Sınav 3";
                worksheet.Cell(1, 7).Value = "Ortalama";
                worksheet.Cell(1, 8).Value = "Durum";

                var notlar = db.TblNotlar.ToList();

                int satır = 2;

                foreach (var not in notlar)
                {
                    worksheet.Cell(satır, 1).Value = not.TblOgrenciler.OgrenciAd;
                    worksheet.Cell(satır, 2).Value = not.TblOgrenciler.OgrenciSoyad;
                    worksheet.Cell(satır, 3).Value = not.TblDersler?.DersAd;
                    worksheet.Cell(satır, 4).Value = not.Sınav1;
                    worksheet.Cell(satır, 5).Value = not.Sınav2;
                    worksheet.Cell(satır, 6).Value = not.Sınav3;
                    worksheet.Cell(satır, 7).Value = not.Ortalama;

                    if (not.Durum == true)
                    {
                        worksheet.Cell(satır, 8).Value = "Geçti";
                    }
                    else
                    {
                        worksheet.Cell(satır, 8).Value = "Kaldı";
                    }
                    satır++;
                }



                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OgrenciListesi.xlsx");
                }
            }

            // bu süslü parantezlerin içine yazacaksın.


        }
    }
}
