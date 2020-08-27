using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Spifield.Controllers
{
    public class MonsterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Fight(int monsterID)
        {
            // obliczanie wyników walki

            // zwrócenie rezultatu


            return View();
        }
    }
}