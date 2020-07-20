using ChaosCC.DataLayer.Abstract;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfModelDal : IModelDal
    {
        private ChaosContext _context = new ChaosContext();

        public Model Add(Model Model)
        {
            _context.Modeller.Add(Model);
            _context.SaveChanges();
            return Model;
        }

        public void Delete(int id)
        {
            Model ModelUpdate = Get(id);
            if (ModelUpdate == null)
            {
                throw new Exception("Model bulunamadığı için silme işlemi yapılamadı.");
            }
            ModelUpdate.Aktif = false;
            _context.SaveChanges();
        }

        public List<Model> Get(Model search)
        {
            var ModellarDto = _context.Modeller
                .Include("Marka")
                .Where(k =>
                        (search.Id == 0 || k.Id == search.Id) &&
                        (search.Adi == null || k.Adi == search.Adi) &&
                        (search.MarkaId == null || k.MarkaId == search.MarkaId) && 
                        k.Aktif == true
                )
                .OrderBy(k => k.Adi).ToList();

            return ModellarDto;
        }

        public Model Get(int id)
        {
            return _context.Modeller.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
        }

        public Model Update(Model ent)
        {
            Model newEnt = Get(ent.Id);
            newEnt.Adi = ent.Adi;
            newEnt.MarkaId = ent.MarkaId;          

            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
