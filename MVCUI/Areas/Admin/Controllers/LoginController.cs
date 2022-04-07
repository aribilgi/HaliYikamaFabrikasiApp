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
        public ActionResult Index(string KullaniciAdi, string Sifre, string ReturnUrl) // Adres çubuğundaki query string deki ReturnUrl i de parametrede alıyoruz
        {
            var sonuc = manager.Get(k => k.KullaniciAdi == KullaniciAdi.Trim() & k.Sifre == Sifre.Trim() & k.Durum);
            if (sonuc != null)
            {
                Session["admin"] = sonuc;
                FormsAuthentication.SetAuthCookie(sonuc.KullaniciAdi, true);
                return ReturnUrl == null ? RedirectToAction("Index", "Default") : (ActionResult)Redirect(ReturnUrl); // ReturnUrl adres çubuğunda boşsa default index sayfasına değilse ReturnUrl de yazan adrese git
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Sistemden çıkış için bu metodu çalıştırıyoruz
            return RedirectToAction("Index", "Login"); // Çıkıştan sonra sayfayı tekrar login ekranına yönlendir
        }
    }
}