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
            var DTOs = Mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs);
            return View(DTOs);
        }
    }
}