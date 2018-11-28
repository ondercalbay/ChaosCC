﻿using ChaosCC.BusinessLayer;
using ChaosCC.DataLayer.EntityFramework;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using ChaosCC.UIYonetim.Helpers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;

namespace ChaosCC.UIYonetim.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciManager _servis = new KullaniciManager(new EfKullaniciDal());
        private readonly IEtkinlikManager _servisEtkinlik = new EtkinlikManager(new EfEtkinlikDal(), new EfKullaniciDal());

        public KullanicilarController(IKullaniciManager kullaniciServis)
        {
            _servis = kullaniciServis;

        }

        public ActionResult Login()
        {
            return View(new KullaniciLoginDto());
        }

        [HttpPost]
        public ActionResult Login(KullaniciLoginDto kullanici, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                KullaniciSessionDto kullaniciAuth = _servis.Authenticate(kullanici);
                if (kullaniciAuth == null)
                {
                    ModelState.AddModelError("Hata", "Kullanıcı adı veya şifresi hatalı.");
                }
                else
                {
                    UserHelper.AddCookies(kullaniciAuth, false);

                    return Redirect(returnUrl ?? "/");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        // GET: Kullanici
        [Authorize]
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
        //        kullaniciDto = _servis.Get(Convert.ToInt32(Request["id"]));
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Kullanicilar Yeni";
        //    }

        //    return View(kullaniciDto);
        //}
        [Authorize]
        public ActionResult Edit(int? id)
        {
            KullaniciEditDto kullaniciDto = new KullaniciEditDto();
            if (id != null)
            {
                ViewBag.Message = "Kullanicilar Düzenle";
                kullaniciDto = _servis.Get(Convert.ToInt32(id));
                kullaniciDto.SifreTekrar = kullaniciDto.Sifre;
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

        [Authorize]
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

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _servis.Delete(id);
            return RedirectToAction("");

        }

        [Authorize]
        public ActionResult Devamsizlik(int id)
        {
            KullaniciEditDto kullaniciDto = new KullaniciEditDto();
            ViewBag.Kullanici = _servis.Get(id).KullaniciAdi;

            List<KullaniciDevamsizlikDto> devamsizlikDto = _servisEtkinlik.GetKullaniciDevamsizlik(id);
            kullaniciDto.SifreTekrar = kullaniciDto.Sifre;


            return View(devamsizlikDto);
        }

        [Authorize]
        public ActionResult DevamsizlikList()
        {
            List<KullaniciListDto> kullaniciDto = _servis.Get(new Kullanici { Aktif = true });

            List<KullaniciDevamsilikListDto> dto = new List<KullaniciDevamsilikListDto>();

            foreach (var kullanici in kullaniciDto)
            {
                KullaniciDevamsilikListDto devamsizlik = new KullaniciDevamsilikListDto();
                devamsizlik.Kullanici = kullanici;
                devamsizlik.Devamsizlik = _servisEtkinlik.GetKullaniciDevamsizlik(kullanici.Id);
                dto.Add(devamsizlik);
            }

            return View(dto);
        }


    }
}