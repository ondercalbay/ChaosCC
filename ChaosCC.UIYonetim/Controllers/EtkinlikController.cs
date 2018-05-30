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
            DevamsizlikGridDto dto = new DevamsizlikGridDto();
            dto.Id = id;
            
            dto.Etkinlik = _service.Get(id);
            dto.Grid = _service.GetDevamsizlik(id);            
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Devamsizlik(DevamsizlikGridDto model)
        {
            _service.SaveDevamsizlik(model);

            return RedirectToAction("");
        }


    }
}
