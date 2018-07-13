using ChaosCC.DataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaosCC.Entity;
using System.Data.Entity.Validation;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfDuyuruDal : IDuyuruDal
    {
        private ChaosContext _context = new ChaosContext();

        public Duyuru Add(Duyuru ent)
        {
            try
            {
                _context.Duyurular.Add(ent);
                _context.SaveChanges();
                return ent;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
            catch (Exception ex)
            {

                throw ex;
            }

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
             (filter.Id == 0 || t.Id == filter.Id) &&
             t.Aktif == true).ToList();
        }

        public Duyuru Get(int id)
        {
            return _context.Duyurular.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
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
