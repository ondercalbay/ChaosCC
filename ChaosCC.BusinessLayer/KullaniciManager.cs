using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;

namespace ChaosCC.BusinessLayer
{
    public class KullaniciManager : IKullaniciManager
    {
        private IKullaniciDal _dal { get; set; }

        public KullaniciManager(IKullaniciDal dal)
        {
            _dal = dal;
        }

        public KullaniciEditDto Add(KullaniciEditDto editDto)
        {
            Kullanici ent = Mapper.Map<KullaniciEditDto, Kullanici>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<Kullanici, KullaniciEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<KullaniciListDto> Get(Kullanici filter)
        {
            return Mapper.Map<List<KullaniciListDto>>(_dal.Get(filter));
        }

        public KullaniciEditDto Get(int id)
        {
            return Mapper.Map<KullaniciEditDto>(_dal.Get(id));
        }

        public KullaniciEditDto Update(KullaniciEditDto editDto)
        {
            Kullanici ent = Mapper.Map<Kullanici>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<KullaniciEditDto>(_dal.Update(ent));
        }
    }
}
