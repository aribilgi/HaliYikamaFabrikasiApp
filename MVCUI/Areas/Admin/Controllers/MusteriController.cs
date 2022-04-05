using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    public class MusteriController : Controller
    {
        MusteriManager manager = new MusteriManager();
        // GET: Admin/Musteri
        public ActionResult Index()
        {
            return View(manager.GetAll());
        }


        // GET: Admin/Musteri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Musteri/Create
        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            try
            {
                if (ModelState.IsValid) // Eğer modelden gelen validasyon kuralları geçerliyse
                {
                    // Buradaki kodları işlet
                    //musteri.EklenmeTarihi = DateTime.Now;
                    int sonuc = manager.Add(musteri);
                    if (sonuc > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Eklenemedi!"); // Bu kod satırı model state e kendi özel hatamızı eklemek için kullanılır Mvc de.
            }
            return View(musteri); // eğer yukardaki kodlar çalışmazsa ön yüze oradan gelen musteri nesnesini oluşan hatalarla beraber geri gönder ki ekranda hataları görebilsin kullanıcı
        }

        // GET: Admin/Musteri/Edit/5
        public ActionResult Edit(int id)
        {
            var kayit = manager.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // POST: Admin/Musteri/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Musteri musteri)
        {
            try
            {
                if (ModelState.IsValid) // Eğer modelden gelen validasyon kuralları geçerliyse
                {
                    // Buradaki kodları işlet
                    int sonuc = manager.Update(musteri);
                    if (sonuc > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu! Kayıt Güncellenemedi!");
            }
            return View(musteri);
        }

        // GET: Admin/Musteri/Delete/5
        public ActionResult Delete(int id)
        {
            var kayit = manager.Find(id);
            if (kayit == null)
            {
                return HttpNotFound();
            }
            return View(kayit);
        }

        // POST: Admin/Musteri/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var kayit = manager.Find(id); // silinecek kaydı bul
                manager.Delete(kayit);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
