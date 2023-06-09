using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler=c.Carilers.Where(x=>x.Durum==true).ToList();

            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var ktg = c.Carilers.Find(id);
           ktg.Durum=false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var Cari = c.Carilers.Find(id);
            return View("CariGetir", Cari);
        }

        public ActionResult CariGuncelle(Cariler k)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var ktgr = c.Carilers.Find(k.Cariid);
            c.Entry(ktgr).CurrentValues.SetValues(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cariAd = c.Carilers.Where(x => x.Cariid == id).Select(y=>y.CariAd+ " "+ y.CariSoyad).FirstOrDefault();
            ViewBag.CariAd = cariAd;    
            return View(degerler);
        }
    }
}