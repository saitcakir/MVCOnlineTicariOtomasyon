using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context c = new Context();
        // GET: Urun
        public ActionResult Index()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();    
            return RedirectToAction("Index");
        }
    }
}