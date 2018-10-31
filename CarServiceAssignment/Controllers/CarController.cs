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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<CarDTO> carDTOs = carService.GetCars();
            var carViewModel = Mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs).SingleOrDefault(c => c.Id == id);

            if(carViewModel == null)
            {
                return NotFound();
            }

            return View(carViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CarViewModel carViewModel)
        {
            var carDTO = Mapper.Map<CarViewModel, CarDTO>(carViewModel);
            carService.UpdateCarInfo(carDTO);
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            carService.DeleteCar(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarViewModel carViewModel)
        {
            
            var carDTO = Mapper.Map<CarViewModel, CarDTO>(carViewModel);
            carService.CreateCar(carDTO);

            return RedirectToAction("Index");
        }
    }
}