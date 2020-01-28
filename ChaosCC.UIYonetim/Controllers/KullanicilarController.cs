using ChaosCC.BusinessLayer;
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
using static ChaosCC.Entity.Enumlar;

namespace ChaosCC.UIYonetim.Controllers
{
    [Authorize]
    public class KullanicilarController : Controller
    {
        private readonly IKullaniciManager _servis = new KullaniciManager(new EfKullaniciDal());
        private readonly IEtkinlikManager _servisEtkinlik = new EtkinlikManager(new EfEtkinlikDal(), new EfKullaniciDal());

        public KullanicilarController(IKullaniciManager kullaniciServis)
        {
            _servis = kullaniciServis;

        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new KullaniciLoginDto());
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        
        public ActionResult Devamsizlik(int id)
        {
            KullaniciEditDto kullaniciDto = new KullaniciEditDto();
            ViewBag.Kullanici = _servis.Get(id).KullaniciAdi;

            List<KullaniciDevamsizlikDto> devamsizlikDto = _servisEtkinlik.GetKullaniciDevamsizlik(id, new DateTime(DateTime.Today.Year, 01, 01), DateTime.Today);
            kullaniciDto.SifreTekrar = kullaniciDto.Sifre;


            return View(devamsizlikDto);
        }

        
        public ActionResult DevamsizlikList(EnuTarihAralik enuTarihAralik = EnuTarihAralik.Son1Sene)
        {
            ViewBag.TarihAralik = enuTarihAralik;
            List<KullaniciListDto> kullaniciDto = _servis.Get(new Kullanici { Aktif = true });

            List<KullaniciDevamsilikListDto> dto = new List<KullaniciDevamsilikListDto>();
            DateTime dateBas = DateTime.Today;
            DateTime dateBit = DateTime.Today;

            switch (enuTarihAralik)
            {
                case EnuTarihAralik.Son3Ay:
                    dateBas = DateTime.Today.AddMonths(-3);
                    break;
                case EnuTarihAralik.Son6Ay:
                    dateBas = DateTime.Today.AddMonths(-6);
                    break;
                case EnuTarihAralik.BuSune:
                    dateBas = new DateTime(DateTime.Today.Year, 1, 1);
                    break;
                case EnuTarihAralik.Son1Sene:
                    dateBas = DateTime.Today.AddYears(-1);
                    break;
                case EnuTarihAralik.Tümü:
                    dateBas = DateTime.MinValue;
                    dateBit = DateTime.MaxValue;
                    break;
                default:
                    break;
            }

            foreach (var kullanici in kullaniciDto)
            {
                KullaniciDevamsilikListDto devamsizlik = new KullaniciDevamsilikListDto();
                devamsizlik.Kullanici = kullanici;

          

              
                devamsizlik.Devamsizlik = _servisEtkinlik.GetKullaniciDevamsizlik(kullanici.Id, dateBas, dateBit);
                dto.Add(devamsizlik);
            }

            return View(dto);
        } 
    }
}