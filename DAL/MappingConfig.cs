using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Model;

namespace DAL.Mapping
{
    public class MappingConfig
    {
        /*
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DAL.Student, Model.Student>();
        });
    */
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Model.Database.Activity, Model.Domain.Activity>();

                config.CreateMap<Model.Database.ActivityType, Model.Domain.ActivityType>();

                config.CreateMap<Model.Database.Users, Model.Domain.Users>()
                .ForMember(
                    dest => dest.Password,
                    opt => opt.Ignore())
                    .ForMember(
                    dest => dest.PasswordByte,
                    opt => opt.MapFrom
                    (src => src.Password));

                config.CreateMap<Model.Database.Status, Model.Domain.Status>();

                config.CreateMap<Model.Database.Comment, Model.Domain.Comment>();

            });
        }

    }
}