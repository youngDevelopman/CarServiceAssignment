using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServiceAssignment.BLL.MapperSettings
{
    public static class MapConfiguration
    {
        public static void MapModels(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Car, CarDTO>().ForMember(dto => dto.CarOwners, opt => opt.MapFrom(x => x.CarOwners.Select(y => y.Owner).ToList()));
            cfg.CreateMap<CarDTO, Car>().ForMember(dto => dto.CarOwners, opt => opt.MapFrom(x => x.CarOwners.Select(y => y.CarOwners).ToList()));

            cfg.CreateMap<Owner, OwnerDTO>().ForMember(dto => dto.CarOwners, opt => opt.MapFrom(x => x.CarOwners.Select(y => y.Owner).ToList()));
            cfg.CreateMap<OwnerDTO, Owner>().ForMember(dto => dto.CarOwners, opt => opt.MapFrom(x => x.CarOwners.Select(y => y.CarOwners).ToList()));
        }
    }
}
