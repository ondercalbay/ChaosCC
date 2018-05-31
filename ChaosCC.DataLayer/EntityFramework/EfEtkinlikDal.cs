using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfEtkinlikDal : IEtkinlikDal
    {
        private ChaosContext _context = new ChaosContext();

        public Etkinlik Add(Etkinlik ent)
        {
            _context.Etkinlikler.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        public Devamsizlik AddDevamsizlik(Devamsizlik ent)
        {
            _context.Devamsizliklar.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        public void Delete(int id)
        {
            var ent = Get(id);
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<Etkinlik> Get(Etkinlik filter)
        {
            return _context.Etkinlikler
                .Where(t =>                
                        (filter.Id == 0 || t.Id == filter.Id) &&
                        t.Aktif == true
                    )
                .OrderByDescending(t=> t.Tarih).ToList();
        }

        public Etkinlik Get(int id)
        {
            return Get(new Etkinlik { Id = id }).FirstOrDefault();
        }

        public List<DevamsizlikListDto> GetDevamsizlikWithEtkinlikId(int etkinlikId)
        {


            var query = _context.Devamsizliklar
                .Where(t => t.EtkinlikId == etkinlikId && t.Aktif == true).
                Select(t => new DevamsizlikListDto
                {
                    Id = t.Id,
                    KullaniciId = t.KullaniciId,
                    KullaniciAdi = t.Kullanici.KullaniciAdi,
                    Geldi = t.Geldi,
                    Aciklama = t.Aciklama
                })
                .OrderBy(t => t.KullaniciAdi);




            //var query = from k in _context.Kullanicilar
            //            join d in _context.Devamsizliklar on k.Id equals d.KullaniciId into listDevamsizliklar
            //            from ld in listDevamsizliklar.DefaultIfEmpty()
            //            join e in _context.Etkinlikler on ld.EtkinlikId equals e.Id into listetkinlikler
            //            from le in listetkinlikler.DefaultIfEmpty()
            //            orderby k.KullaniciAdi
            //            select new DevamsizlikListDto
            //            {
            //                Id = ld.Id != null ? (int)ld.Id : 0,
            //                KullaniciId = k.Id,
            //                KullaniciAdi = k.KullaniciAdi,
            //                Geldi = ld.Geldi != null ? ld.Geldi : true,
            //                Aciklama = ld.Aciklama
            //            };

            //_context.Database.SqlQuery()
            //return _context.Etkinlikler.Join<.Where(t =>
            //(filter.Id == 0 || t.Id == filter.Id) &&
            //t.Aktif == true).ToList();

            return query.ToList();
        }



        public Etkinlik Update(Etkinlik ent)
        {
            Etkinlik newEnt = Get(ent.Id);
            newEnt.Aciklama = ent.Aciklama;
            newEnt.EtlinlikTuru = ent.EtlinlikTuru;
            newEnt.Tarih = ent.Tarih;
            newEnt.Yer = ent.Yer;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }

        public List<Devamsizlik> GetDevamsizlik(Devamsizlik filter)
        {
            return _context.Devamsizliklar.Where(t =>
             (filter.Id == 0 || t.Id == filter.Id) &&
             (filter.EtkinlikId == 0 || t.EtkinlikId == filter.EtkinlikId) &&
             (filter.KullaniciId == 0 || t.KullaniciId == filter.KullaniciId) &&
             t.Aktif == true).ToList();
        }

        public Devamsizlik GetDevamsizlik(int id)
        {
            return GetDevamsizlik(new Devamsizlik { Id = id }).FirstOrDefault();
        }

        public Devamsizlik UpdateDevamsizlik(Devamsizlik ent)
        {
            Devamsizlik newEnt = GetDevamsizlik(ent.Id);
            newEnt.EtkinlikId = ent.EtkinlikId;
            newEnt.KullaniciId = ent.KullaniciId;
            newEnt.Geldi = ent.Geldi;
            newEnt.Aciklama = ent.Aciklama;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            newEnt.Aktif = ent.Aktif;
            _context.SaveChanges();

            return ent;
        }

        public void DevamsizlikDelete(int id)
        {
            var ent = GetDevamsizlik(id);
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<KullaniciEditDto> GetKullaniciWitOutEtkinlik(int id)
        {
            var etkinligeKatilanKullanicilar = _context.Devamsizliklar.Where(t => t.EtkinlikId == id && t.Aktif == true).Select(t => t.KullaniciId);

            return _context.Kullanicilar
                .Where(k => !etkinligeKatilanKullanicilar.Contains(k.Id) && k.Aktif == true)
                .Select(t =>
                new KullaniciEditDto()
                {
                    Id = t.Id,
                    Adi = t.Adi,
                    Soyadi = t.Soyadi,
                    KullaniciAdi = t.KullaniciAdi
                }
                ).ToList();
        }
    }
}
