using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security; // login için gerekli güvenlik kütüphanesi
using System.Web.Mvc;
using BL;

namespace MVCUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        LoginManager manager = new LoginManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string KullaniciAdi, string Sifre)
        {
            var sonuc = manager.Get(k => k.KullaniciAdi == KullaniciAdi.Trim() & k.Sifre == Sifre.Trim() & k.Durum);
            if (sonuc != null)
            {
                Session["admin"] = sonuc;
                FormsAuthentication.SetAuthCookie(sonuc.KullaniciAdi, true);
            }
            return View();
        }
    }
}