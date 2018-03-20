using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;

namespace ChaosCC.BusinessLayer
{
    public class EtkinlikManager : IEtkinlikManager
    {
        private IEtkinlikDal _dal { get; set; }
        public EtkinlikManager(IEtkinlikDal dal)
        {
            _dal = dal;
        }
        public EtkinlikEditDto Add(EtkinlikEditDto editDto)
        {
            Etkinlik ent = Mapper.Map<Etkinlik>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<EtkinlikEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<EtkinlikListDto> Get(Etkinlik filter)
        {
            return Mapper.Map<List<Etkinlik>, List<EtkinlikListDto>>(_dal.Get(filter));
        }

        public EtkinlikEditDto Get(int id)
        {
            return Mapper.Map<EtkinlikEditDto>(_dal.Get(id));
        }

        public EtkinlikEditDto Update(EtkinlikEditDto editDto)
        {
            Etkinlik ent = Mapper.Map<Etkinlik>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<EtkinlikEditDto>(_dal.Update(ent));
        }

        public List<DevamsizlikListDto> GetDevamsizlik(int etkinlikId)
        {

            List<DevamsizlikListDto> ent = _dal.GetDevamsizlik(etkinlikId);

            List<DevamsizlikListDto> result = new List<DevamsizlikListDto>();

            return ent;
        }
    }
}