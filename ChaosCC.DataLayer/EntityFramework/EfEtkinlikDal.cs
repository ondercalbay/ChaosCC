using ChaosCC.DataLayer.Abstract;
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

        public Etkinlik Update(Etkinlik ent)
        {
            Etkinlik newEnt = Get(ent.Id);
            newEnt.Aciklama = ent.Aciklama;
            newEnt.EtlinlikTuru = ent.EtlinlikTuru;
            newEnt.Tarih= ent.Tarih;
            newEnt.Yer = ent.Yer;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
