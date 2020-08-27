using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Races.Any())
            {
                context.AddRange(
                new Race { RaceID = 1, Name = "Olbrzym", BaseAttackDamage = 10, BaseVitality = 10, BaseAgility = 10, BaseDefence = 10, BaseDexterity = 10 },
                new Race { RaceID = 2, Name = "Elf", BaseAttackDamage = 5, BaseVitality = 5, BaseAgility = 5, BaseDefence = 5, BaseDexterity = 5 },
                new Race { RaceID = 3, Name = "Draenei", BaseAttackDamage = 5, BaseVitality = 5, BaseAgility = 5, BaseDefence = 5, BaseDexterity = 5 },
                new Race { RaceID = 4, Name = "Człowiek", BaseAttackDamage = 5, BaseVitality = 5, BaseAgility = 5, BaseDefence = 5, BaseDexterity = 5 }
                    );
            }

            if (!context.Locations.Any())
            {
                context.AddRange(
                new Location { LocationID = 1, Name = "Dalur", Description = "Dolina", ReuqiredLevel = 1 },
                new Location { LocationID = 2, Name = "Setberg", Description = "Góry skaliste", ReuqiredLevel = 10 },
                new Location { LocationID = 3, Name = "Leifar", Description = "Ruiny", ReuqiredLevel = 20 }
                    );
            }

            if (!context.Monsters.Any())
            {
                context.AddRange(
                new Monster { MonsterID = 1, Name = "#DalurMonster1", Level = 1, AttackDamage = 1, Dexterity = 1, Vitality = 1, Agility = 1, Defence = 1, MiniatureURL = "adres", LocationID = 1 }
                    );
            }

            // przedmioty

            context.SaveChanges();
        }
    }
}
