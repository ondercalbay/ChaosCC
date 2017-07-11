using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;

namespace ChaosCC.BusinessLayer
{
    public class DuyuruManager : IDuyuruManager
    {
        private IDuyuruDal _dal { get; set; }
        public DuyuruManager(IDuyuruDal dal)
        {
            _dal = dal;
        }
        public DuyuruEditDto Add(DuyuruEditDto editDto)
        {
            Duyuru ent = Mapper.Map<Duyuru>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<DuyuruEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<DuyuruListDto> Get(Duyuru filter)
        {
            return Mapper.Map<List<Duyuru>, List<DuyuruListDto>>(_dal.Get(filter));
        }

        public DuyuruEditDto Get(int id)
        {
            return Mapper.Map<DuyuruEditDto>(_dal.Get(id));
        }

        public DuyuruEditDto Update(DuyuruEditDto editDto)
        {
            Duyuru ent = Mapper.Map<Duyuru>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<DuyuruEditDto>(_dal.Update(ent));
        }
    }
}
