using HayatSulama.Areas.yonetim.Models.DB;
using HayatSulama.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HayatSulama.Controllers
{

    public class UrunlerController : Controller
    {
        PasHabbazEntities db = new PasHabbazEntities();
        // GET: Urunler
        public ActionResult Index(int? sayfa)
        {
            UrunKategoriler urunler = new UrunKategoriler();
            urunler.Urunler = db.TBLURUNLER.Where(t => t.ID > 0 && t.ARSIV == 1).Take(20).ToList();
            urunler.Kategoriler = db.TBLKATEGORILER.Where(x => x.ID > 0 && x.ARSIV == 1).ToList();
            urunler.UrunResimleri = db.TBLURUNRESIMLERI.Where(a => a.URUN_ID == a.TBLURUNLER.ID && a.ARSIV == 1 && a.TBLURUNLER.ARSIV == 1).ToList();
            return View(urunler);
        }
     

        public ActionResult UrunDetay(int id)
        {
            Urunler urunler = new Urunler();
            var urun = db.TBLURUNLER.FirstOrDefault(z => z.ID == id && z.ARSIV == 1);

            urunler.urun_aciklama = urun.URUN_ACIKLAMA;
            urunler.urun_adi = urun.URUN_ADI;
            urunler.fiyat = urun.FIYAT;
            urunler.urun_ayrintilar = urun.URUN_AYRINTILAR;
            urunler.resimleri = db.TBLURUNRESIMLERI.Where(z => z.URUN_ID == id && z.ARSIV == 1 && z.TBLURUNLER.ARSIV == 1).ToList();
            urunler.urun_kategorisi = db.TBLKATEGORILER.FirstOrDefault(x => x.ID == urun.URUN_KATEGORI && x.ARSIV == 1).KATEGORI_ADI;

            return View(urunler);
        }


        public ActionResult Kategori(int id, int? sayfa)  //kategori idsi
        {
            UrunKategoriler urunler = new UrunKategoriler();
           urunler.UrunKategori = db.TBLURUNLER.Where(z => z.URUN_KATEGORI == id && z.ARSIV == 1).OrderBy(a => a.TARIH).ToPagedList(sayfa ?? 1, 10);
            urunler.Kategoriler = db.TBLKATEGORILER.Where(x => x.ID > 0 && x.ARSIV == 1).ToList();
            urunler.UrunResimleri = db.TBLURUNRESIMLERI.Where(a => a.URUN_ID == a.TBLURUNLER.ID && a.ARSIV == 1 && a.TBLURUNLER.ARSIV == 1).ToList();
            return View(urunler);
        }
    }
}
