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
            var DTOs = Mapper.Map<IEnumerable<Car>, IEnumerable<CarDTO>>(Database.Cars.GetAll());
            return DTOs;
        }

        public void UpdateCarInfo(CarDTO carDTO)
        {
            var updatedCar = Mapper.Map<CarDTO, Car>(carDTO);
            Database.Cars.Update(updatedCar);
            Database.Save();
        }

        public void DeleteCar(int id)
        {
            Database.Cars.Delete(id);
            Database.Save();
        }

        public void CreateCar(CarDTO carDTO)
        {
            var createdCar = Mapper.Map<CarDTO, Car>(carDTO);
            Database.Cars.Create(createdCar);
            Database.Save();
        }
    }
}
