using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.BusinessLayer
{
    public class ModelManager : IModelManager
    {
        private IModelDal _dal { get; set; }
        public ModelManager(IModelDal dal)
        {
            _dal = dal;
        }
        public ModelEditDto Add(ModelEditDto editDto)
        {
            Model ent = Mapper.Map<Model>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<ModelEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<ModelListDto> Get(Model filter)
        {
            return Mapper.Map<List<Model>, List<ModelListDto>>(_dal.Get(filter));
        }

        public ModelEditDto Get(int id)
        {
            return Mapper.Map<ModelEditDto>(_dal.Get(id));
        }

        public ModelEditDto Update(ModelEditDto editDto)
        {
            Model ent = Mapper.Map<Model>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<ModelEditDto>(_dal.Update(ent));
        }

        public List<ModelListDto> GetListByMarkaId(int markaId)
        {
            Model filter = new Model { MarkaId = markaId, Aktif = true };
            return _dal.Get(filter)
                .Select(i => new ModelListDto
                {
                    Id = i.Id,
                    Adi = i.Adi,
                    MarkaId = i.Marka.Id,
                    MarkaAdi = i.Marka.Adi
                }).ToList();
        }
    }
}
