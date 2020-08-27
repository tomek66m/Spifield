using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spifield.Model;
using Spifield.Models;
using Spifield.Models.Repositories;
using Spifield.ViewModels;

namespace Spifield.Controllers
{
    // authorized
    public class CharacterController : Controller
    {

        private AppDbContext appDbContext;
        private readonly ICharacterRepository _ICharacterRepository;
        private readonly IMonsterRepository _IMonsterRepository;
        private readonly IItemRepository _IItemRepository;
        private readonly UserManager<AppUser> _userManager;


        public CharacterController(AppDbContext AppDbContext, ICharacterRepository ICharacterRepository, IMonsterRepository IMonsterRepository, IItemRepository IItemRepository, UserManager<AppUser> userManager)
        {
            appDbContext = AppDbContext;
            _ICharacterRepository = ICharacterRepository;
            _userManager = userManager;
            _IMonsterRepository = IMonsterRepository;
            _IItemRepository = IItemRepository;

        }

        private readonly int startSilfrQuantity = 500;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CharacterCreateVM();
            vm.RacesList = new List<SelectListItem>();
            foreach(var x in appDbContext.Races)
            {
                vm.RacesList.Add(new SelectListItem(x.Name, x.RaceID.ToString()));
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CharacterCreateVM create)
        {
            // TODO polaczenie modelu CharacterCreateVM z listą ras z bazy danych
            if (ModelState.IsValid)
            {
                
                var newCharacter = new Character
                {
                    Name = create.Name,
                    Race = appDbContext.Races.FirstOrDefault(x=>x.RaceID==create.RaceID),
                    Experience = 0,
                    Level = 1,
                    SilfrQuantity = startSilfrQuantity,
                    AdditionalAgility = 0,
                    AdditionalAtttackDamage = 0,
                    AdditionalDefence = 0,
                    AdditionalDexterity = 0,
                    AdditionalVitality = 0,
                    StatPoints = 0
                };

                _ICharacterRepository.AddCharacter(newCharacter);

                var currentUser = appDbContext.Users.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
                currentUser.IsCharacterCreated = true;
                currentUser.AccountCharacterID = newCharacter.CharacterID;
               
                appDbContext.SaveChanges();


                // dodanie startowych itemow
                for (int i = 1; i <= 7; i++)
                    _ICharacterRepository.AddItem(i, currentUser.AccountCharacterID);

                return RedirectToAction("Index", "Home");
            }


            create.RacesList = new List<SelectListItem>();
            foreach (var x in appDbContext.Races)
            {
                create.RacesList.Add(new SelectListItem(x.Name, x.RaceID.ToString()));
            }
            return View(create);
        }

        [HttpGet]
        public async Task<IActionResult> Info()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var character = _ICharacterRepository.GetCharacter(user.AccountCharacterID);

            return View(character);
        }

        [HttpGet]
        public IActionResult GetInventory(int id)
        {
            var _allItems = _IItemRepository.GetAllCharacterItems(id);
            var _wieldedItems = _IItemRepository.GetCharacterWieldedItems(id);


            return View(new AllCharacterInventoryVM { allItems = _allItems, wieldedItems = _wieldedItems });
        }

        [HttpGet]
        public IActionResult EquipItem(int id, string type, int characterid)
        {
            _IItemRepository.equipItem(id, type, characterid);

            return RedirectToAction("GetInventory", "Character", new { id = characterid });
        }
    }
}