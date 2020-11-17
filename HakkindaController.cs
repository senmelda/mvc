using HayatSulama.Areas.yonetim.Models.DB;
using HayatSulama.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayatSulama.Controllers
{

    public class HakkindaController : Controller
    {

        PasHabbazEntities db = new PasHabbazEntities();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            Hakkimizda getir = new Hakkimizda();
            var hakkimizda = db.TBLHAKKIMIZDA.FirstOrDefault(t => t.ID > 0 && t.ARSIV == 1);


            getir.hakkimizda_baslik = hakkimizda.HAKKIMIZDA_BASLIK;
            getir.hakkimizda_aciklama = hakkimizda.HAKKIMIZDA_ACIKLAMA;
            getir.resim_url = hakkimizda.RESIM_URL;



            return View(getir);
        }

       
    }
}