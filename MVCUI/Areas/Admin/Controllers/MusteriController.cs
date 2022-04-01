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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Musteri/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Musteri/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Musteri/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Musteri/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
