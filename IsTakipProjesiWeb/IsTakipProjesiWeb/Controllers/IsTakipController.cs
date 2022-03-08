using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsTakipProjesiWeb.Models.Entity;

namespace IsTakipProjesiWeb.Controllers
{
    [Authorize]
    public class IsTakipController : Controller
    {
        // GET: IsTakip
        public ActionResult AnaIsTakip()
        {
            return View();
        }
        public ActionResult AktifCagri()
        {
            var main = (string)Session["Mail"];

            var id = Baglanti.db.TFirma.Where(v => v.Mail == main).Select(w => w.ID).FirstOrDefault();

            var x2 = Baglanti.db.TCagri.Where(c => c.Durum == true && c.CagriFirma == id).ToList();

            var cagriSayisi = Baglanti.db.TCagri.Where(x => x.Durum == true && x.CagriFirma == id).Count();


            if (cagriSayisi == 0)
            {
                ViewBag.CagriSayisi = "Aktif Çağrınız bulunmamaktadır.";
            }
            return View(x2);
        }
        public ActionResult PasifCagri()
        {
            var main = (string)Session["Mail"];
            var id = Baglanti.db.TFirma.Where(v => v.Mail == main).Select(w => w.ID).FirstOrDefault();
            var x = Baglanti.db.TCagri.Where(c => c.Durum == false && c.CagriFirma == id).ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult YeniCagri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCagri(TCagri c)
        {
            var main = (string)Session["Mail"];
            var id = Baglanti.db.TFirma.Where(v => v.Mail == main).Select(w => w.ID).FirstOrDefault();
            c.CagriFirma = id;
            c.Durum = true;
            c.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            Baglanti.db.TCagri.Add(c);
            Baglanti.db.SaveChanges();
            return RedirectToAction("AktifCagri");
        }
        public ActionResult CagriDetay(byte id)
        {
            var x = Baglanti.db.TCagriDetay.Find(id);
            var y = Baglanti.db.TCagriDetay.Where(v => v.ID == id).ToList();
            return View(y);
        }
        public ActionResult CagriGuncelle(TCagri c)
        {
            var x = Baglanti.db.TCagri.Find(c.ID);
            x.Aciklama = c.Aciklama;
            x.Durum = c.Durum;
            x.Konu = c.Konu;
            Baglanti.db.SaveChanges();
            return RedirectToAction("AktifCagri");
        }

        public ActionResult CagriGetir(byte id)
        {
            var x = Baglanti.db.TCagri.Find(id);
            return View("CagriGetir", x);

        }
        [HttpGet]
        public ActionResult Profil()
        {
            var main = (string)Session["Mail"];
            var id = Baglanti.db.TFirma.Where(v => v.Mail == main).Select(w => w.ID).FirstOrDefault();
            var profil = Baglanti.db.TFirma.Where(c => c.ID == id).FirstOrDefault();
            return View(profil);
        }
        public ActionResult ProfilGuncelle(TFirma f)
        {
            var main = (string)Session["Mail"];
            var id = Baglanti.db.TFirma.Where(v => v.Mail == main).Select(w => w.ID).FirstOrDefault();
            var x = Baglanti.db.TFirma.Find(id);
            x.Adres = f.Adres;
            x.Yetkili = f.Yetkili;
            x.Il = f.Il;
            x.Telefon = f.Telefon;
            x.Sifre = f.Sifre;
            x.Sektor = f.Sektor;
            Baglanti.db.SaveChanges();
            return RedirectToAction("Profil");
        }
    }
}