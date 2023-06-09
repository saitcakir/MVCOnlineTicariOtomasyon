using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = c.Personels.Find(id);
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var prs = c.Personels.Find(p.Personelid);
            c.Entry(prs).CurrentValues.SetValues(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelDurum(int id)
        {
            Personel prs = c.Personels.Find(id);
            prs.Durum = prs.Durum == true ? false : true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var personelAd = c.Personels.Where(x => x.Personelid == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.PersonelAd = personelAd;
            return View(degerler);
        }
    }
}