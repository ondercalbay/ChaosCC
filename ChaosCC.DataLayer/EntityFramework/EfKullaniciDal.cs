using ChaosCC.DataLayer.Abstract;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChaosCC.DataLayer.EntityFramework
{
    public class EfKullaniciDal : IKullaniciDal
    {
        private ChaosContext _context = new ChaosContext();

        public Kullanici Add(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
            return kullanici;
        }

        public void Delete(int id)
        {
            Kullanici kullaniciUpdate = Get(id);
            if (kullaniciUpdate == null)
            {
                throw new Exception("Kullanici bulunamadığı için silme işlemi yapılamadı.");
            }
            kullaniciUpdate.Aktif = false;
            _context.SaveChanges();
        }

        public List<Kullanici> Get(Kullanici search)
        {
            var kullanicilarDto = _context.Kullanicilar
                .Where(k =>
                        (search.Id == 0 || k.Id == search.Id) &&
                        (search.Adi == null || k.Adi == search.Adi) &&
                        (search.Soyadi == null || k.Soyadi == search.Soyadi) &&
                        (search.KullaniciAdi == null || k.KullaniciAdi == search.KullaniciAdi) &&
                        (search.EMail == null || k.EMail == search.EMail) &&
                        (search.Sifre == null || k.Sifre == search.Sifre) &&
                        (search.Aktif == null || k.Aktif == true)
                )
                .OrderByDescending(k => k.EklemeZamani).ToList();

            return kullanicilarDto;
        }

        public Kullanici Get(int id)
        {
            return _context.Kullanicilar.Where(k => k.Id == id && k.Aktif == true).FirstOrDefault();
        }

        public Kullanici Update(Kullanici ent)
        {
            Kullanici newEnt = Get(ent.Id);
            newEnt.Adi = ent.Adi;
            newEnt.Soyadi = ent.Soyadi;
            newEnt.KullaniciAdi = ent.KullaniciAdi;
            newEnt.Sifre = ent.Sifre;
            newEnt.EMail = ent.EMail;
            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
