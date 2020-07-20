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
    public class MarkaManager : IMarkaManager
    {
        private IMarkaDal _dal { get; set; }
        public MarkaManager(IMarkaDal dal)
        {
            _dal = dal;
        }
        public MarkaEditDto Add(MarkaEditDto editDto)
        {
            Marka ent = Mapper.Map<Marka>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<MarkaEditDto>(_dal.Add(ent));
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<MarkaListDto> Get(Marka filter)
        {
            return Mapper.Map<List<Marka>, List<MarkaListDto>>(_dal.Get(filter));
        }

        public MarkaEditDto Get(int id)
        {
            return Mapper.Map<MarkaEditDto>(_dal.Get(id));
        }

        public MarkaEditDto Update(MarkaEditDto editDto)
        {
            Marka ent = Mapper.Map<Marka>(editDto);
            ent.EkleyenId = 1;
            ent.EklemeZamani = DateTime.Now;
            ent.GuncelleyenId = 1;
            ent.GuncellemeZamani = DateTime.Now;
            ent.Aktif = true;
            return Mapper.Map<MarkaEditDto>(_dal.Update(ent));
        }
    }
}
