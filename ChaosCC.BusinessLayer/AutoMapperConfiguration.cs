﻿using AutoMapper;
using ChaosCC.Dto;
using ChaosCC.Entity;

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

                cfg.CreateMap<Kullanici, KullaniciLoginDto>();
                cfg.CreateMap<KullaniciLoginDto, Kullanici>();

                cfg.CreateMap<Kullanici, KullaniciLoginDto>();
                cfg.CreateMap<KullaniciLoginDto, Kullanici>();
                
                cfg.CreateMap<Kullanici, KullaniciSessionDto>();
                cfg.CreateMap<KullaniciSessionDto, Kullanici>();



                cfg.CreateMap<Duyuru, DuyuruListDto>();
                cfg.CreateMap<DuyuruListDto, Duyuru>();

                cfg.CreateMap<Duyuru, DuyuruEditDto>();
                cfg.CreateMap<DuyuruEditDto, Duyuru>();

                cfg.CreateMap<Etkinlik, EtkinlikListDto>();
                cfg.CreateMap<EtkinlikListDto, Etkinlik>();

                cfg.CreateMap<Etkinlik, EtkinlikEditDto>();
                cfg.CreateMap<EtkinlikEditDto, Etkinlik>();

                cfg.CreateMap<Marka, MarkaEditDto>();
                cfg.CreateMap<MarkaEditDto, Marka>();

                cfg.CreateMap<Model, ModelEditDto>();
                cfg.CreateMap<ModelEditDto, Model>();

                cfg.CreateMap<Motosiklet, MotosikletEditDto>();
                cfg.CreateMap<MotosikletEditDto, Motosiklet>();
            }
            );


        }
    }
}
