using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spifield.Model;
using Spifield.Models;
using Spifield.Models.Repositories;

namespace Spifield.Controllers
{
    public class LocationController : Controller
    {
        private AppDbContext appDbContext;
        private readonly ILocationRepository _ILocationRepository;


        public LocationController(AppDbContext AppDbContext, ILocationRepository ILocationRepository)
        {
            appDbContext = AppDbContext;
            _ILocationRepository = ILocationRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LocationList()
        {
            return View(_ILocationRepository.getLocations());
        }

        [HttpGet]
        public IActionResult LocationMonsters(int id)
        {
            return View(_ILocationRepository.getMonstersFromLocation(id));
        }
    }
}