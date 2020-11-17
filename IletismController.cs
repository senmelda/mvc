using HayatSulama.Areas.yonetim.Models.DB;
using HayatSulama.Areas.yonetim.Models.VM;
using HayatSulama.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HayatSulama.Controllers
{
    public class IletismController : Controller
    {
        PasHabbazEntities db = new PasHabbazEntities();
        // GET: Iletisim
        public ActionResult Index()
        {
            Iletisim getir = new Iletisim();
            var iletisim = db.TBLILETISIM.FirstOrDefault(t => t.ID > 0 && t.ARSIV == 1);


            getir.adres1 = iletisim.ADRES1;
            getir.il1 = iletisim.IL1;
            getir.ilce1 = iletisim.ILCE1;
            getir.adres2 = iletisim.ADRES2;
            getir.il2 = iletisim.IL2;
            getir.ilce2 = iletisim.ILCE2;
            getir.eposta = iletisim.EPOSTA;
            getir.telefon1 = iletisim.TELEFON1;
            getir.telefon2 = iletisim.TELEFON2;
            getir.telefon3 = iletisim.TELEFON3;
            getir.telefon4 = iletisim.TELEFON4;
            getir.facebook = iletisim.FACEBOOK;
            getir.twitter = iletisim.TWITTER;
            getir.linkedin = iletisim.LINKEDIN;
            getir.harita = iletisim.HARITA;
            getir.instagram = iletisim.INSTAGRAM;




            return View(getir);
        }

        [HttpPost]
        public ActionResult mailgonder(string adi, string mailadresi, string MailKonusu, string Mesaj)
        {

            var receivereEmail = new MailAddress("muhasebe@HayatSulama.com");
            var password = "Vq7A1Y66";
            var content = "<b> Websitemizden gelen E-mail </b><br><table align ='left' style ='undefined;table-layout: fixed; width : 535 px'><tr><td>Ad Soyad</td><td>:</td><td>" + adi + " </ td></tr><tr><td>Konu</td><td>:</td><td>" + MailKonusu + "</td></tr><tr><td>E - Mail </td><td>:</td><td>" + mailadresi + "</td></tr><tr><td>Mesaj</td><td>:</td><td>" + Mesaj + "</td><tr><tr><td> TARİH </td ><td>:</td><td>" + DateTime.Now + "</td><tr></table>";
            var smtp = new SmtpClient
            {
                Host = "smtp.HayatSulama.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(receivereEmail.Address, password)
            };
            using (var mess = new MailMessage(receivereEmail, receivereEmail)
            {
                IsBodyHtml = true,
                Subject = mailadresi,
                Body = content

            })
            {
                smtp.Send(mess);
            }
            return RedirectToAction("Index");
        }

    }
}