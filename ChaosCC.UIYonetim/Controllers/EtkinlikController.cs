using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChaosCC.UIYonetim.Controllers
{
    public class EtkinlikController : Controller
    {
        private IEtkinlikManager _service;

        public EtkinlikController(IEtkinlikManager service)
        {
            _service = service;
        }

        // GET: Etkinlik
        public ActionResult Index()
        {
            return View(_service.Get(new Etkinlik()).OrderByDescending(x => x.Tarih));
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            EtkinlikEditDto editDto;
            if (id == null)
            {
                editDto = new EtkinlikEditDto { Tarih = DateTime.Today };
            }
            else
            {
                editDto = _service.Get(Convert.ToInt32(id));
            }
            return View(editDto);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(EtkinlikEditDto editDto)
        {
            ViewBag.Message = "Etkinlik";
            if (editDto.Id == 0)
            {
                _service.Add(editDto);
            }
            else
            {
                _service.Update(editDto);
            }
            return RedirectToAction("");

        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Devamsizlik(int id)
        {
            DevamsizlikGridDto grid = new DevamsizlikGridDto();
            grid.Grid = _service.GetDevamsizlik(Convert.ToInt32(id));

            return View(grid.Grid);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Devamsizlik(FormCollection form)
        {

            List<DevamsizlikListDto> gridInsert = new List<DevamsizlikListDto>();
            List<DevamsizlikListDto> gridUpdate = new List<DevamsizlikListDto>();

            List<DevamsizlikListDto> grid = new List<DevamsizlikListDto>();


            for (int i = 0; i < form["item.Id"].Split(',').Length; i++)
            {
                DevamsizlikListDto item = new DevamsizlikListDto();
                item.Id = Convert.ToInt32(form["item.Id"].Split(',')[i]);
                item.Aciklama = form["item.Aciklama"].Split(',')[i];
                item.EtkinlikAdi = form["item.EtkinlikAdi"].Split(',')[i];
                item.Geldi = Convert.ToBoolean(form["item.Geldi"].Split(',')[i]);
                item.KullaniciAdi = form["item.KullaniciAdi"].Split(',')[i];
                item.KullaniciId = Convert.ToInt32(form["item.KullaniciId"].Split(',')[i]);

                grid.Add(item);
            }

            return View(grid);
        }


    }
}
