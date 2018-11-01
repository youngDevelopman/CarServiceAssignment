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

        public OwnerController(IOwnerService service)
        {
            ownerService = service;
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
    }
}