using AutoMapper;
using ChaosCC.Dto;
using ChaosCC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosCC.BusinessLayer
{
    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            //MapperConfiguration config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<List<Kullanici>, List<KullaniciListDto>>();
            //    cfg.CreateMap<List<KullaniciListDto>, List<Kullanici>>();
            //    cfg.CreateMap<Kullanici, KullaniciEditDto>();
            //    cfg.CreateMap<KullaniciEditDto, Kullanici>();
            //});
            //Mapper.Initialize(cfg =>
            //    cfg.AddProfiles(new[]{
            //        typeof(Kullanici) ,
            //        typeof(KullaniciListDto),
            //        typeof(List<Kullanici>),
            //        typeof(List<KullaniciListDto>),
            //        typeof(KullaniciEditDto)
            //    })
            //);

            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<List<Kullanici>, List<KullaniciListDto>>();
                //cfg.CreateMap<List<KullaniciListDto>, List<Kullanici>>();
                cfg.CreateMap<Kullanici, KullaniciListDto>();
                cfg.CreateMap<KullaniciListDto, Kullanici>();
                cfg.CreateMap<Kullanici, KullaniciEditDto>();
                cfg.CreateMap<KullaniciEditDto, Kullanici>();

            }
            );


        }
    }
}
