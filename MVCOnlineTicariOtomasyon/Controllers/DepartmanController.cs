using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman u)
        {
            c.Departmans.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var ktg = c.Departmans.Find(id);
            ktg.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanGetir(int id)
        {
            var Departman = c.Departmans.Find(id);
            return View("DepartmanGetir", Departman);
        }

        public ActionResult DepartmanGuncelle(Departman k)
        {
            var ktgr = c.Departmans.Find(k.DepartmanId);
            ktgr.DepartmanAd = k.DepartmanAd;
            ktgr.Durum = k.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList();
            var dpt = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.DepartmanAd = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var personelAd = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.PersonelAd = personelAd;
            return View(degerler);
        }
    }
}