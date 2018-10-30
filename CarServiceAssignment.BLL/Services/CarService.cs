using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarServiceAssignment.BLL.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork Database { get; set; }

        public CarService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<CarDTO> GetCars()
        {
            //Mapper.CreateMap<GoodEntity, GoodDTO>()
            //    .ForMember(dto => dto.providers, opt => opt.MapFrom(x => x.GoodsAndProviders.Select(y => y.Providers).ToList()));
            var DTOs = Mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(Database.Cars.GetAll());
            return DTOs;
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            //return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(Database.Cars.GetAll());
        }
    }
}
