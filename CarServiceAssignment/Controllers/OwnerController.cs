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
    }
}