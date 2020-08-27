using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spifield.Model;
using Spifield.Models;
using Spifield.Models.Repositories;
using Spifield.ViewModels;

namespace Spifield.Controllers
{
    public class FightController : Controller
    {
        
        private AppDbContext appDbContext;
        private readonly ICharacterRepository _ICharacterRepository;
        private readonly IMonsterRepository _IMonsterRepository;
        private readonly IItemRepository _IItemRepository;
        private readonly UserManager<AppUser> _userManager;

        public FightController(AppDbContext AppDbContext, ICharacterRepository ICharacterRepository, IMonsterRepository IMonsterRepository, IItemRepository IItemRepository, UserManager<AppUser> userManager)
        {
            appDbContext = AppDbContext;
            _ICharacterRepository = ICharacterRepository;
            _userManager = userManager;
            _IMonsterRepository = IMonsterRepository;
            _IItemRepository = IItemRepository;
        }
        [HttpGet]
        public IActionResult FightWithMonster(int id)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);

            // problem do zbadania w komentarzu na dole
            Character character = _ICharacterRepository.GetCharacter(user.Result.AccountCharacterID);// czy to bedzie dzialac jezeli nie nadazy z wczytaniem user??
            // dodane rasy do characteru
            character.Race = appDbContext.Races.FirstOrDefault(x => x.RaceID == character.RaceID);

            // pobranie statystyki postaci i rasy
            // character+rasa

            // pobranie informacji o potworze
            var monster = _IMonsterRepository.GetMonster(id);

            // 1 kalkukacja zwinności
            // zwinność - unik
            double characterAgility = Convert.ToDouble(character.Race.BaseAgility + character.AdditionalAgility); // race moze byc nullem
            double monsterAgility = Convert.ToDouble(monster.Agility);
            //

            // zręczność - szansa na trafienie
            double characterDexterity = Convert.ToDouble(character.Race.BaseDexterity + character.AdditionalDexterity);
            double monsterDexterity = Convert.ToDouble(monster.Dexterity);
            //

            // liczenie przewagi statystyk

            double characterDeffence = character.Race.BaseDefence + character.AdditionalDefence;
            double monsterDeffence = monster.Defence;

            double characterVitality = character.Race.BaseVitality + character.AdditionalVitality;
            var monsterVitality = monster.Vitality;

            double characterDMG = character.Race.BaseAttackDamage + character.AdditionalAtttackDamage;
            double monsterDMG = monster.AttackDamage;

            //

            // dodanie statystyk z itemów
            var characterItems = _IItemRepository.GetCharacterWieldedItems(character.CharacterID); // PROBLEM ZOSTALO NULL

            if(characterItems.Count!=0)
                characterDMG += characterItems.FirstOrDefault(c=>c.Type=="Weapon").Damage;
            
            foreach(var x in characterItems)
            {
                characterAgility += x.Agility;
                characterDexterity += x.Dexterity;
                characterDeffence += x.Defence;
                characterVitality += x.Vitality;
            }
            //

            // hit chance

            double characterChanceToHit = characterDexterity / (characterDexterity + monsterAgility) * 100;
            double monsterChanceToHit = monsterDexterity / (monsterDexterity + characterAgility) * 100;


            var tourMaxCount = 15;

            // zakażdy punkt vitala 10 razy więcej hp

            double characterCurrentHP = characterVitality * 10;
            double monsterCurrentHP = monsterVitality * 10;

            bool endOfFight = false;

            RoundVM roundVM = new RoundVM();
            bool characterWin = false;
            for (int i = 1; i <= tourMaxCount; i++)
            {

                if (characterCurrentHP <= 0 || monsterCurrentHP <= 0 || i==tourMaxCount+1)
                {
                    endOfFight = true;
                    if (characterCurrentHP > monsterCurrentHP)
                        characterWin = true;
                }

                if (!endOfFight)
                {
                    ParticipantsMoves currentMove = new ParticipantsMoves();

                    // obliczenie obrazen

                    // czy zadanie obrazen sie powiodlo
                    bool isCharacterHittedMonster = false;
                    bool isMonsterHittedCharacter = false;

                    Random hittingChanceCalculator = new Random();

                    int randNumber = hittingChanceCalculator.Next(0, 100);

                    if (randNumber <= characterChanceToHit)
                    {
                        isCharacterHittedMonster = true;
                    }
                    if (randNumber <= monsterChanceToHit)
                    {
                        isMonsterHittedCharacter = true;
                    }

                    double characterDamagerDealt = 0; // obrazenia jakie zadal gracz
                    double monsterDamageDealt = 0; // obrazenia jakie zadal potwor
                    // obliczna obrazen jakie zadal gracz
                    if(isCharacterHittedMonster)
                    {
                        // obliczenie sumy obrazen
                        characterDamagerDealt = characterDMG * (100 / 100 + Math.Round(monsterDeffence/66, 0)) ;

                        monsterCurrentHP -= characterDamagerDealt;
                    }
                    else
                    {
                        characterDamagerDealt = 0;
                    }

                    // obliczanie obrazen jakie zadal potwor
                    if(isMonsterHittedCharacter)
                    {
                        monsterDamageDealt = monsterDMG * (100 / 100 + Math.Round(characterDeffence / 66, 0));

                        characterCurrentHP -= monsterDamageDealt;
                    }
                    else
                    {
                        monsterDamageDealt = 0;
                    }

                    // przekazanie wyniku tury do VM
                    currentMove.moveID = i;
                    currentMove.CharacterHP = characterCurrentHP;
                    currentMove.MonsterHP = monsterCurrentHP;
                    currentMove.CharacterDamage = characterDamagerDealt;
                    currentMove.MonsterDamage = monsterDamageDealt;

                    roundVM.particispantsMoves.Add(currentMove);

                }
            }

            roundVM.IsPlayerWon = characterWin;
            roundVM.MonsterHitChance = monsterChanceToHit;
            roundVM.CharacterHitChance = characterChanceToHit;

            if(characterWin)
            {
                character.Experience += 50;

                if(character.Experience >= appDbContext.LevellingTables.FirstOrDefault(c=>c.LevelID==(character.Level+1)).ExperienceNeeded)
                {
                    character.Level += 1;
                }

                appDbContext.SaveChanges();
            }

            return View(roundVM);

        }
    }
}