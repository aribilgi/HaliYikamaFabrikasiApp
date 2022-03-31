using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    public class KullaniciYonetimiController : Controller
    {
        KullaniciManager manager = new KullaniciManager();
        // GET: Admin/KullaniciYonetimi
        public ActionResult Index()
        {
            // No connection string named 'DatabaseContext' could be found in the application config file. Eğer bu hatayı alırsak bunun anlamı projemizin web.config dosyasında veritabanına bağlanmak için gereken DatabaseContext isminde bir connection string olmamasıdır!!! 
            // Web form veya windows form projelerinin app.config veya web.config dosyalarından kopyalayıp buradaki aynı dosyaya yapıştırarak bu sorunu çözebiliriz!

            return View(manager.GetAll()); // View içerisinde veri listesini ön yüz sayfasına bu şekilde gönderebiliryoruz
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Kullanici kullanici)
        {
            if (ModelState.IsValid) // Eğer modelden gelen validasyon kuralları geçerliyse
            {
                // Buradaki kodları işlet
                int sonuc = manager.Add(kullanici);
                if (sonuc > 0)
                {
                    return Redirect("Index");
                }
            }
            
            return View(kullanici);
        }
    }
}