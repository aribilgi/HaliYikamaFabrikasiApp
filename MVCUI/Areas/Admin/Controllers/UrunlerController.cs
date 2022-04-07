using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL;
using Data.DAL;
using Entities;

namespace MVCUI.Areas.Admin.Controllers
{
    [Authorize] // Urunler Controller ındaki tüm actionlara erişim için admin girişini gerekli kıl
    public class UrunlerController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        UrunManager manager = new UrunManager();
        // GET: Admin/Urunler
        public ActionResult Index()
        {
            var urunler = db.Urunler.Include(u => u.Musteri); // Include metodu entity frameworkde ilişkili tabloyu sorguya dahil edip Sql deki join işlemini yapmak için kullanılır
            return View(urunler.ToList());
        }

        // GET: Admin/Urunler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = db.Urunler.Find(id);
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // GET: Admin/Urunler/Create
        public ActionResult Create()
        {
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi"); // Ön yüzdeki drop down list-select elemanına mvc de veri bu şekilde gönderiliyor. Burada önemli nota ViewBag.MusteriId ismi ile ön yüzdeki MusteriId isminin aynı olması!
            return View();
        }

        // POST: Admin/Urunler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urunler.Add(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", urun.MusteriId);
            return View(urun);
        }

        // GET: Admin/Urunler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = manager.Find(id.Value); //db.Urunler.Find(id); Otomatik oluşan metot
            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", urun.MusteriId);
            return View(urun);
        }

        // POST: Admin/Urunler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MusteriId = new SelectList(db.Musteriler, "Id", "Adi", urun.MusteriId);
            return View(urun);
        }

        // GET: Admin/Urunler/Delete/5
        public ActionResult Delete(int? id) // ? buranın boş gelebileceğini ifade eder
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urun urun = manager.Find(id.Value);// eğer metoda parametreden gelen id değişkeni ? ile boş geçilebilir yapılmışsa id.value yazmamız gerekiyor //db.Urunler.Find(id); otomatik oluşan
            if (urun == null)
            {
                return HttpNotFound();
            }
            return View(urun);
        }

        // POST: Admin/Urunler/Delete/5
        [HttpPost, ActionName("Delete")] // Buradaki ActionName("Delete") attribütü adı DeleteConfirmed olan bu metodun Delete actionuna gelecek olan istekler için çalışmasını sağlar böylece delete adında 2 action olmasından kaynaklı oluşacak hatayı engeller
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urun urun = manager.Find(id); //db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); // db nesnesinin işi bittiğinde bellekten kaldırarak uygulama performansını artırır
            }
            base.Dispose(disposing);
        }
    }
}
