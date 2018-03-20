using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(int id)
        {
            var ent = Get(id);
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<Etkinlik> Get(Etkinlik filter)
        {
            return _context.Etkinlikler.Where(t =>
             (filter.Id == 0 || t.Id == filter.Id) &&
             t.Aktif == true).ToList();
        }

        public Etkinlik Get(int id)
        {
            return Get(new Etkinlik { Id = id }).FirstOrDefault();
        }

        public List<DevamsizlikListDto> GetDevamsizlik(int etkinlikId)
        {
            var query = from k in _context.Kullanicilar
                        join d in _context.Devamsizliklar on k.Id equals d.KullaniciId into listDevamsizliklar
                        from ld in listDevamsizliklar.DefaultIfEmpty()
                        join e in _context.Etkinlikler on ld.EtkinlikId equals e.Id into listetkinlikler
                        from le in listetkinlikler.DefaultIfEmpty()
                        orderby k.KullaniciAdi
                        select new DevamsizlikListDto
                        {
                            Id = ld.Id != null ? (int)ld.Id : 0,
                            EtkinlikAdi = le.EtlinlikTuru + "-" + le.Yer,
                            KullaniciId = k.Id,
                            KullaniciAdi = k.KullaniciAdi,
                            Geldi = ld.Geldi != null ? ld.Geldi : true,
                            Aciklama = ld.Aciklama
                        };
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
    }
}
