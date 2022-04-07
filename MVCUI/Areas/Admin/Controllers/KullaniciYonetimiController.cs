using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize]
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
                kullanici.EklenmeTarihi = DateTime.Now;
                int sonuc = manager.Add(kullanici);
                if (sonuc > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            
            return View(kullanici);
        }
        public ActionResult Edit(int id)
        {
            var kayit = manager.Find(id);
            if (kayit == null)
            {
                return HttpNotFound(); // Eğer gelen id ye ait kayıt db de yoksa ekrana sayfa bulunamadı hatası ver
            }
            return View(kayit);
        }
        [HttpPost]
        public ActionResult Edit(Kullanici kullanici)
        {
            if (ModelState.IsValid) // Eğer modelden gelen validasyon kuralları geçerliyse
            {
                // Buradaki kodları işlet
                int sonuc = manager.Update(kullanici);
                if (sonuc > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(kullanici);
        }
        public ActionResult Delete(int id)
        {
            var kayit = manager.Find(id);
            if (kayit == null)
            {
                return HttpNotFound(); // Eğer gelen id ye ait kayıt db de yoksa ekrana sayfa bulunamadı hatası ver
            }
            return View(kayit);
        }
        [HttpPost]
        public ActionResult Delete(int id, Kullanici kullanici)
        {
            var kayit = manager.Find(id); // silinecek kaydı bul
            manager.Delete(kayit); // delete metoduna silinecek kaydı yolla
            return RedirectToAction("Index"); // sayfayı index-liste sayfasına yönlendir
        }
    }
}