using AutoMapper;
using ChaosCC.DataLayer.Abstract;
using ChaosCC.Dto;
using ChaosCC.Entity;
using ChaosCC.InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.BusinessLayer
{
    public class MotosikletManager : IMotosikletManager
    {
        private IMotosikletDal _dal { get; set; }
        public MotosikletManager(IMotosikletDal dal)
        {
            _dal = dal;
        }
        public MotosikletEditDto Add(MotosikletEditDto editDto)
        {
            Motosiklet ent = Mapper.Map<Motosiklet>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<MotosikletEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<MotosikletListDto> Get(Motosiklet filter)
        {
            return Mapper.Map<List<Motosiklet>, List<MotosikletListDto>>(_dal.Get(filter));
        }

        public MotosikletEditDto Get(int id)
        {
            return Mapper.Map<MotosikletEditDto>(_dal.Get(id));
        }

        public MotosikletEditDto Update(MotosikletEditDto editDto)
        {
            Motosiklet ent = Mapper.Map<Motosiklet>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<MotosikletEditDto>(_dal.Update(ent));
        }
    }
}
