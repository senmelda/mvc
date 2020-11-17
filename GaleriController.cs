using HayatSulama.Areas.yonetim.Models.DB;
using HayatSulama.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayatSulama.Controllers
{
    public class GaleriController : Controller
    {
        PasHabbazEntities db = new PasHabbazEntities();
        // GET: Galeri
        public ActionResult Index()
        {
            var slider = db.TBLGALERI.Where(t => t.ID > 0 && t.ARSIV == 1).Select(t => new Galeriler
            {
                id = t.ID,

                resim_url = t.RESIM_URL


            }).ToList();

            return View(slider);
            //deneme zehra
        }
    }
}