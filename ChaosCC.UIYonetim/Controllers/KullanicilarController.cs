using ChaosCC.BusinessLayer;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.DataLayer.EntityFramework;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Web.Mvc;


namespace ChaosCC.UIYonetim.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciManager _servis = new KullaniciManager(new EfKullaniciDal());

        public KullanicilarController(IKullaniciManager kullaniciServis)
        {
            _servis = kullaniciServis;
        }
        // GET: Kullanici        
        public ActionResult Index()
        {
            ViewBag.Message = "Kullanicilar";

            return View(_servis.Get(new Kullanici { Aktif = true }));
        }

        //public ActionResult Edit()
        //{
        //    KullaniciEditDto kullaniciDto = new KullaniciEditDto();
        //    if (Request["id"] != "")
        //    {
        //        ViewBag.Message = "Kullanicilar Düzenle";
        //        kullaniciDto = manager.Get(Convert.ToInt32(Request["id"]));
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Kullanicilar Yeni";
        //    }

        //    return View(kullaniciDto);
        //}

        public ActionResult Edit(int? id)
        {
            KullaniciEditDto kullaniciDto = new KullaniciEditDto();
            if (id != null)
            {
                ViewBag.Message = "Kullanicilar Düzenle";
                kullaniciDto = _servis.Get(Convert.ToInt32(id));
            }
            else
            {
                ViewBag.Message = "Kullanicilar Yeni";
            }

            return View(kullaniciDto);
        }

        //public ActionResult Edit(int id)
        //{
        //    ViewBag.Message = "Kullanicilar";
        //    return View(manager.Get(id));
        //}

        [HttpPost]
        public ActionResult Edit(KullaniciEditDto kullanici)
        {
            ViewBag.Message = "Kullanicilar";
            if (kullanici.Id == 0)
            {
                _servis.Add(kullanici);
            }
            else
            {
                _servis.Update(kullanici);
            }
            return RedirectToAction("");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _servis.Delete(id);
            return RedirectToAction("");

        }
    }
}