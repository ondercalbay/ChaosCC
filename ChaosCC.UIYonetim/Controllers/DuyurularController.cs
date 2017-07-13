using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Web.Mvc;

namespace ChaosCC.UIYonetim.Controllers
{
    public class DuyurularController : Controller
    {
        private IDuyuruManager _service;

        public DuyurularController(IDuyuruManager service)
        {
            _service = service;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_service.Get(new Duyuru()));
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            DuyuruEditDto editDto;
            if (id == null)
            {
                editDto = new DuyuruEditDto { Tarih = DateTime.Now };
            }
            else
            {
                editDto = _service.Get(Convert.ToInt32(id));
            }
            return View(editDto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(DuyuruEditDto editDto)
        {
            ViewBag.Message = "Kullanicilar";
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
    }
}