using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.BLL.Services;
using CarServiceAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceAssignment.Controllers
{
    public class CarController : Controller
    {
        ICarService carService;

        public CarController(ICarService service)
        {
            carService = service;
        }

        public IActionResult Index()
        {
            IEnumerable<CarDTO> carDTOs = carService.GetCars();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, CarViewModel>()).CreateMapper();
            var carsViewModels = mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs);
            return View(carsViewModels);
        }
    }
}