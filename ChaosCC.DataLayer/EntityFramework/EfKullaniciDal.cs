using ChaosCC.CommonLibrary;
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
                        (search.EPosta == null || k.EPosta == search.EPosta) &&
                        (search.Sifre == null || k.Sifre == search.Sifre) &&
                        k.Aktif == true
                )
                .OrderBy(k => k.KullaniciAdi).ToList();

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
            newEnt.EPosta = ent.EPosta;
            newEnt.DogumTarihi = ent.DogumTarihi;
            newEnt.EhliyetOn = ent.EhliyetOn;
            newEnt.EhliyetArka = ent.EhliyetArka;
            newEnt.Kangrubu = ent.Kangrubu;
            newEnt.Rol = ent.Rol;
            newEnt.Rutbesi = ent.Rutbesi;
            newEnt.VoyagerRozet = ent.VoyagerRozet;
            newEnt.Cep = ent.Cep;
            newEnt.Yakin = ent.Yakin;
            newEnt.YakinCep = ent.YakinCep;

            if (ent.Sifre.IsNotNull())
            {
                newEnt.Sifre = ent.Sifre;
            }

            newEnt.GuncelleyenId = ent.GuncelleyenId;
            newEnt.GuncellemeZamani = DateTime.Now;
            _context.SaveChanges();

            return ent;
        }
    }
}
