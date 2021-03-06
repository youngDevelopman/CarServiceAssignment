﻿using System;
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
            IEnumerable<CarViewModel> carViewModel = Mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs);

            return View(carViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<CarDTO> carDTOs = carService.GetCars();
            CarViewModel carViewModel = Mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs).SingleOrDefault(c => c.Id == id);

            if(carViewModel == null)
            {
                return NotFound();
            }

            return View(carViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CarViewModel carViewModel)
        {
            if (ModelState.IsValid)
            {
                CarDTO carDTO = Mapper.Map<CarViewModel, CarDTO>(carViewModel);
                carService.UpdateCarInfo(carDTO);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
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
        public IActionResult Create([Bind(include:new string[] { "Brand","Model","Type","Price","Year","CarOwners" })]CarViewModel carViewModel)
        {

            if (ModelState.IsValid)
            {
                CarDTO carDTO = Mapper.Map<CarViewModel, CarDTO>(carViewModel);
                carService.CreateCar(carDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}