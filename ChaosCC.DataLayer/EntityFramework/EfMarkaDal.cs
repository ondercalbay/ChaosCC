using ChaosCC.DataLayer.Abstract;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfMarkaDal : IMarkaDal
    {
        private ChaosContext _context = new ChaosContext();

        public Marka Add(Marka Marka)
        {
            _context.Markalar.Add(Marka);
            _context.SaveChanges();
            return Marka;
        }

        public void Delete(int id)
        {
            Marka MarkaUpdate = Get(id);
            if (MarkaUpdate == null)
            {
                throw new Exception("Marka bulunamadığı için silme işlemi yapılamadı.");
            }
            MarkaUpdate.Aktif = false;
            _context.SaveChanges();
        }

        public List<Marka> Get(Marka search)
        {
            var MarkalarDto = _context.Markalar                
                .Where(k =>
                        (search.Id == 0 || k.Id == search.Id) &&
                        (search.Adi == null || k.Adi == search.Adi) &&                        
                        k.Aktif == true
                )
                .OrderBy(k => k.Adi).ToList();

            return MarkalarDto;
        }

        public Marka Get(int id)
        {
            return _context.Markalar.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
        }

        public Marka Update(Marka ent)
        {
            Marka newEnt = Get(ent.Id);
            newEnt.Adi = ent.Adi;          
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
