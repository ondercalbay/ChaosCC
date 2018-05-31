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
        private IKullaniciDal _dalKullanici { get; set; }
        public EtkinlikManager(IEtkinlikDal dal, IKullaniciDal dalKullanici)
        {
            _dal = dal;
            _dalKullanici = dalKullanici;
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
            _dal.DevamsizlikDelete(id);
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

        public DevamsizlikGridDto GetDevamsizlik(int etkinlikId)
        {
            DevamsizlikGridDto result = new DevamsizlikGridDto();
            result.Etkinlik = Mapper.Map<EtkinlikEditDto>(_dal.Get(etkinlikId));
            if (result.Etkinlik == null)
                throw new Exception("Etkinlik bulunamadı.");


            result.Grid = _dal.GetDevamsizlikWithEtkinlikId(etkinlikId);

            //Eğer listeye kullanıcı eklenmediyse tüm kullanıcıları ekle ve tekrar çek
            if (result.Grid.Count == 0)
            {
                var kullanicilar = _dalKullanici.Get(new Kullanici() { Aktif = true });
                foreach (var item in kullanicilar)
                {
                    Devamsizlik devamsizlik = new Devamsizlik()
                    {
                        KullaniciId = item.Id,
                        EtkinlikId = etkinlikId,
                        Geldi = true,
                        EkleyenId = 1,
                        EklemeZamani = DateTime.Now,
                        GuncelleyenId = 1,
                        GuncellemeZamani = DateTime.Now,
                        Aktif = true
                    };
                    _dal.AddDevamsizlik(devamsizlik);
                }
                result.Grid = _dal.GetDevamsizlikWithEtkinlikId(etkinlikId);

                
            }
            
            return result;
        }

        public void SaveDevamsizlik(DevamsizlikGridDto devamsizlikDto)
        {
            List<Devamsizlik> insertModel = new List<Devamsizlik>();
            List<Devamsizlik> updateModel = new List<Devamsizlik>();

            foreach (var item in devamsizlikDto.Grid)
            {
                Devamsizlik ent = new Devamsizlik();
                ent.EtkinlikId = devamsizlikDto.Id;
                ent.KullaniciId = item.KullaniciId;
                ent.Geldi = item.Geldi;
                ent.Aciklama = item.Aciklama;
                ent.EkleyenId = 1;
                ent.EklemeZamani = DateTime.Now;
                ent.GuncelleyenId = 1;
                ent.GuncellemeZamani = DateTime.Now;
                ent.Aktif = true;
                if (item.Id == 0)
                {

                    item.Id = _dal.AddDevamsizlik(ent).Id;
                }
                else
                {
                    ent.Id = item.Id;
                    _dal.UpdateDevamsizlik(ent);
                }
            }
        }

        public void DevamsizlikDelete(int id)
        {
            _dal.DevamsizlikDelete(id);
        }

        public List<KullaniciEditDto> GetKullaniciWitOutEtkinlik(int id)
        {
            return _dal.GetKullaniciWitOutEtkinlik(id);
        }
    }
}