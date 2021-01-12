using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Kitaplık.Models;

namespace MVC_Kitaplık.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        Db_KitapEntities db = new Db_KitapEntities();
        public ActionResult Index()
        {
            var kitaplar = db.Tbl_Kitap.ToList();
            return View(kitaplar);
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(Tbl_Kitap tbl_Kitap)
        {
            
            db.Tbl_Kitap.Add(tbl_Kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.Tbl_Kitap.Find(id);
            db.Tbl_Kitap.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.Tbl_Kitap.Find(id);
            return View("KitapGetir", kitap);

        }

        public ActionResult KitapGuncelle(Tbl_Kitap t)
        {
            var kitap = db.Tbl_Kitap.Find(t.KitapId);
            kitap.Ad = t.Ad;
            kitap.Yazar = t.Yazar;
            kitap.Sayfa = t.Sayfa;
            kitap.Kategori = t.Kategori;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}