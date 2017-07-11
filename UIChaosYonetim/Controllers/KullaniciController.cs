using ChaosCC.BusinessLayer;
using ChaosCC.DataLayer.EntityFramework;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UIChaosYonetim.Controllers
{
    public class KullaniciController : Controller
    {
        IKullaniciManager manager = new KullaniciManager(new EfKullaniciDal());

        // GET: Kullanici        
        public ActionResult Index()
        {
            ViewBag.Message = "Kullanicilar";

            return View(manager.Get(new Kullanici { Aktif = true }));
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
                kullaniciDto = manager.Get(Convert.ToInt32(id));
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
                manager.Add(kullanici);
            }
            else
            {
                manager.Update(kullanici);
            }
            return RedirectToAction("");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            manager.Delete(id);
            return RedirectToAction("");

        }
    }
}