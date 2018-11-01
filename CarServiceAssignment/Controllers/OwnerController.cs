using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarServiceAssignment.BLL.DTO;
using CarServiceAssignment.BLL.Interfaces;
using CarServiceAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceAssignment.Controllers
{
    public class OwnerController : Controller
    {
        IOwnerService ownerService;
        ICarService carService;

        public OwnerController(IOwnerService ownerService, ICarService carService)
        {
            this.ownerService = ownerService;
            this.carService = carService;

        }


        public IActionResult Index()
        {
            IEnumerable<OwnerDTO> ownerDTO = ownerService.GetOwners();
            IEnumerable<OwnerViewModel> ownerViewModel = Mapper.Map<IEnumerable<OwnerDTO>, IEnumerable<OwnerViewModel>>(ownerDTO);

            return View(ownerViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            IEnumerable<OwnerDTO> ownerDTO = ownerService.GetOwners();
            OwnerViewModel ownerViewModel = Mapper.Map<IEnumerable<OwnerDTO>, IEnumerable<OwnerViewModel>>(ownerDTO).SingleOrDefault(c => c.Id == id);

            if (ownerViewModel == null)
            {
                return NotFound();
            }

            return View(ownerViewModel);
        }

        [HttpPost]
        public IActionResult Edit(OwnerViewModel ownerViewModel)
        {
            OwnerDTO ownerDTO = Mapper.Map<OwnerViewModel, OwnerDTO>(ownerViewModel);
            ownerService.UpdateOwnerInfo(ownerDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ownerService.DeleteOwner(id.GetValueOrDefault());

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind(include: new string[] { "FirstName", "LastName", "Birthdate", "DrivingExperience"})]OwnerViewModel ownerViewModel)
        {

            if (ModelState.IsValid)
            {
                OwnerDTO carDTO = Mapper.Map<OwnerViewModel, OwnerDTO>(ownerViewModel);
                ownerService.CreateOwner(carDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddOwnerCar(int? id)
        {
            IEnumerable<CarDTO> carDTOs = carService.GetCars();
            IEnumerable<CarViewModel> carViewModel = Mapper.Map<IEnumerable<CarDTO>, IEnumerable<CarViewModel>>(carDTOs);

            CarOwnerViewModel carOwnerViewModel = new CarOwnerViewModel()
            {
                OwnerId = id.GetValueOrDefault(),
            };

            ViewBag.CarsToChose = new List<CarViewModel>(carViewModel);
            return View(carOwnerViewModel);
        }

        [HttpPost]
        public IActionResult AddOwnerCar(CarOwnerViewModel carOwnerViewModel)
        {
            ownerService.AddCarForOwner(carOwnerViewModel.OwnerId, carOwnerViewModel.CarId);

            return RedirectToAction("Index");
        }
    }
}