using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Drawing.Printing;
using System.Linq;
using System.Web.Mvc;

namespace ChaosCC.UIYonetim.Controllers
{
    public class MotosikletlerController : Controller
    {
        private readonly IMotosikletManager _motosikletService;
        private readonly IKullaniciManager _kullaniciService;
        private readonly IMarkaManager _markaService;
        private readonly IModelManager _modelService;

        public MotosikletlerController(IMotosikletManager motosikletService, IKullaniciManager kullaniciService, IMarkaManager markaService,IModelManager modelService)
        {
            _motosikletService = motosikletService;
            _kullaniciService = kullaniciService;
            _markaService = markaService;
            _modelService = modelService;
        }

        [Authorize]
        public ActionResult Index()
        {            
            return View(_motosikletService.Get(new Motosiklet()));
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            MotosikletEditDto editDto;

            if (id == null)
            {
                editDto = new MotosikletEditDto();
            }
            else
            {
                editDto = _motosikletService.Get(Convert.ToInt32(id));
            }
            LoadKullanicilar(editDto.KullaniciId);
            LoadMarkalar(editDto.MarkaId);
            LoadModeller(editDto.ModelId, editDto.MarkaId);
            return View(editDto);
        }

        private void LoadKullanicilar(int? id)
        {
            ViewBag.Kullanicilar = new SelectList(_kullaniciService.Get(new Kullanici { Aktif = true }), "Id", "KullaniciAdi", id);
        }

        private void LoadMarkalar(int? id)
        {
            ViewBag.Markalar = new SelectList(_markaService.Get(new Marka { Aktif = true }), "Id", "Adi", id);
        }

        private void LoadModeller(int? id,int markaId)
        {
            ViewBag.Modeller = new SelectList(_modelService.Get(new Model { MarkaId = markaId, Aktif = true }), "Id", "Adi", id);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(MotosikletEditDto editDto)
        {
            ViewBag.Message = "Kullanicilar";
            if (editDto.Id == 0)
            {
                _motosikletService.Add(editDto);
            }
            else
            {
                _motosikletService.Update(editDto);
            }
            return RedirectToAction("");

        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _motosikletService.Delete(id);
            return RedirectToAction("");

        }
    }
}