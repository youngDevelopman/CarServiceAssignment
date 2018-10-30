using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.DAL.Entities;
using CarServiceAssignment.DAL.Interfaces;
using System.Collections.Generic;

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
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(Database.Cars.GetAll());
        }
    }
}
