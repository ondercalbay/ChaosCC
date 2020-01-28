using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (MailAdresiKayitlimi(0, editDto.EPosta))
            {
                throw new Exception($"{editDto.EPosta} daha önce kullanılmış. Lütfen başka bir adres giriniz.");
            }

            if (KullaniciAdiKayitlimi(0, editDto.KullaniciAdi))
            {
                throw new Exception($"{editDto.KullaniciAdi} daha önce kullanılmış. Lütfen başka bir Kullanıcı Adı giriniz.");
            }

            Kullanici ent = Mapper.Map<Kullanici>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<KullaniciEditDto>(_dal.Add(ent));
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
            if (MailAdresiKayitlimi(editDto.Id, editDto.EPosta))
            {
                throw new Exception($"{editDto.EPosta} daha önce kullanılmış. Lütfen başka bir adres giriniz.");
            }

            if (KullaniciAdiKayitlimi(editDto.Id, editDto.KullaniciAdi))
            {
                throw new Exception($"{editDto.KullaniciAdi} daha önce kullanılmış. Lütfen başka bir Kullanıcı Adı giriniz.");
            }

            Kullanici ent = Mapper.Map<Kullanici>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<KullaniciEditDto>(_dal.Update(ent));
        }

        public KullaniciSessionDto Authenticate(KullaniciLoginDto kullaniciLoginDto)
        {
            Kullanici ent = Mapper.Map<Kullanici>(kullaniciLoginDto);
            Kullanici kul = _dal.Get(ent).FirstOrDefault();
            if (kul == null)
            {
                return null;
            }
            else
            {
                KullaniciSessionDto result = new KullaniciSessionDto { Id = kul.Id, RolAdi = kul.Rol.ToString() };
                
                return result;
            }


        }

        private bool MailAdresiKayitlimi(int id, string eMail)
        {
            List<Kullanici> ent = _dal.Get(new Kullanici { EPosta = eMail });

            if (id > 0)
            {
                List<Kullanici> silinecek = ent.Where(t => t.Id == id).ToList();
                foreach (var item in silinecek)
                {
                    ent.Remove(item);
                }
            }
            return ent.Count > 0;
        }

        private bool KullaniciAdiKayitlimi(int id, string kullaniciAdi)
        {
            List<Kullanici> ent = _dal.Get(new Kullanici { KullaniciAdi = kullaniciAdi });

            if (id > 0)
            {
                List<Kullanici> silinecek = ent.Where(t => t.Id == id).ToList();
                foreach (var item in silinecek)
                {
                    ent.Remove(item);
                }
            }
            return ent.Count > 0;
        }
    }
}
