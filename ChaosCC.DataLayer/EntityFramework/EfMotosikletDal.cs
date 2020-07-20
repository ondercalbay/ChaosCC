using ChaosCC.DataLayer.Abstract;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfMotosikletDal : IMotosikletDal
    {
        private ChaosContext _context = new ChaosContext();

        public Motosiklet Add(Motosiklet Motosiklet)
        {
            _context.Motosikletler.Add(Motosiklet);
            _context.SaveChanges();
            return Motosiklet;
        }

        public void Delete(int id)
        {
            Motosiklet MotosikletUpdate = Get(id);
            if (MotosikletUpdate == null)
            {
                throw new Exception("Motosiklet bulunamadığı için silme işlemi yapılamadı.");
            }
            MotosikletUpdate.Aktif = false;
            _context.SaveChanges();
        }

        public List<Motosiklet> Get(Motosiklet search)
        {
            var MotosikletlarDto = _context.Motosikletler
                .Include("Kullanici")
                .Include("Model")
                .Include("Marka")
                .Where(k =>
                        (search.Id == 0 || k.Id == search.Id) &&
                        (search.KullaniciId == 0 || k.KullaniciId == search.KullaniciId) &&
                        (search.MarkaId == 0 || k.MarkaId == search.MarkaId) &&
                        (search.ModelId == 0 || k.ModelId == search.ModelId) &&
                        (search.Plaka == null || k.Plaka == search.Plaka) &&
                        k.Aktif == true
                )
                .OrderBy(k => k.Marka.Adi).ThenBy(k=>k.Model.Adi).ToList();

            return MotosikletlarDto;
        }

        public Motosiklet Get(int id)
        {
            return _context.Motosikletler.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
        }

        public Motosiklet Update(Motosiklet ent)
        {
            Motosiklet newEnt = Get(ent.Id);
            newEnt.KullaniciId = ent.KullaniciId;
            newEnt.BaslangicSayacKM = ent.BaslangicSayacKM;
            newEnt.Kullanimda = ent.Kullanimda;
            newEnt.MarkaId = ent.MarkaId;
            newEnt.ModelId = ent.ModelId;
            newEnt.Plaka = ent.Plaka;
            newEnt.SayacKM = ent.SayacKM;
            newEnt.Yil = ent.Yil;            
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
