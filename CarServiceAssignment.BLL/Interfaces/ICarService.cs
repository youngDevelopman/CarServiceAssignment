﻿using CarServiceAssignment.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceAssignment.BLL.Interfaces
{
    public interface ICarService
    {
        IEnumerable<CarDTO> GetCars();
        void UpdateCarInfo(CarDTO carDTO);
        void DeleteCar(int id);
        void CreateCar(CarDTO carViewModel);
    }
}
