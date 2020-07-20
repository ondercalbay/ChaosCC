using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChaosCC.UIYonetim.Controllers
{
    [Authorize]
    public class ModellerController : Controller
    {
        private readonly IMarkaManager _markaService;
        private readonly IModelManager _modelService;

        public ModellerController(IModelManager modelService, IMarkaManager markaService)
        {
            _modelService = modelService;
            _markaService = markaService;
        }

        [Authorize]
        public ActionResult Index(int id)
        {
            return View(_modelService.GetListByMarkaId(id));
        }

        [Authorize]
        public ActionResult Edit(int? id, int markaid)
        {
            ModelEditDto editDto;
            if (id == null)
            {
                var marka = _markaService.Get(markaid);
                editDto = new ModelEditDto { MarkaId = markaid, MarkaAdi = marka.Adi };
            }
            else
            {
                editDto = _modelService.Get(Convert.ToInt32(id));
            }
            return View(editDto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(ModelEditDto editDto)
        {
            ViewBag.Message = "Modeller";
            if (editDto.Id == 0)
            {
                _modelService.Add(editDto);
            }
            else
            {
                _modelService.Update(editDto);
            }
            return RedirectToAction("","Modeller", new { id= editDto.MarkaId });

        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _modelService.Delete(id);
            return RedirectToAction("","Markalar");

        }

        public JsonResult GetJson(int id)
        {
            List<ModelListDto> modeller = _modelService.Get(new Model { MarkaId= id, Aktif = true });            
            return Json(modeller, JsonRequestBehavior.AllowGet);
        }
    }
}