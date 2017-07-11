using ChaosCC.DataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaosCC.Entity;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfDuyuruDal : IDuyuruDal
    {
        private ChaosContext _context = new ChaosContext();

        public Duyuru Add(Duyuru ent)
        {
            _context.Duyurular.Add(ent);
            _context.SaveChanges();
            return ent;
        }

        public void Delete(int id)
        {
            var ent = Get(id);
            ent.Aktif = false;
            _context.SaveChanges();
        }

        public List<Duyuru> Get(Duyuru filter)
        {
            return _context.Duyurular.Where(t =>
             filter.Id == 0 || t.Id == filter.Id &&
             t.Aktif == true).ToList();
        }

        public Duyuru Get(int id)
        {
            return Get(new Duyuru { Id = id }).FirstOrDefault();
        }

        public Duyuru Update(Duyuru ent)
        {
            Duyuru newEnt = Get(ent.Id);
            newEnt.Baslik = ent.Baslik;
            newEnt.Yazi = ent.Yazi;
            newEnt.Tarih = ent.Tarih;
            newEnt.DuyuruTipi = ent.DuyuruTipi;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
