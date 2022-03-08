using IsTakipProjesiWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IsTakipProjesiWeb.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult AnaLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnaLogin(TFirma f)
        {
            var bilgi = Baglanti.db.TFirma.FirstOrDefault(x => x.Mail == f.Mail && x.Sifre == f.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Mail, false);
                Session["Mail"] = bilgi.Mail.ToString();
                return RedirectToAction("AktifCagri", "IsTakip");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AnaLogin", "Login");
        }
    }
}