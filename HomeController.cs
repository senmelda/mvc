using HayatSulama.Areas.yonetim.Models.DB;
using HayatSulama.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayatSulama.Controllers
{
    public class HomeController : Controller
    {
        PasHabbazEntities db = new PasHabbazEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            Anaysafa vm = new Anaysafa();
            
            vm.Urun = db.TBLURUNLER.Where(z => z.ID > 0 && z.ARSIV == 1).ToList();
            vm.Resimler = db.TBLURUNRESIMLERI.Where(a => a.URUN_ID == a.TBLURUNLER.ID && a.ARSIV == 1 && a.TBLURUNLER.ARSIV == 1).ToList();
            
          
            vm.UrunlerKamp = db.TBLURUNLER.Where(z => z.ARSIV == 1 && z.ID > 0 && z.KAMPANYALI == 1).Take(5).ToList();
            vm.Urunler = db.TBLURUNLER.Where(z => z.ARSIV == 1 && z.ID > 0).Take(5).ToList();
            
            return View(vm);
        }

        
    }
}