using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models
{
    // Custome User Properties

    public class AppRole : IdentityRole<int>
    {
        public AppRole()
        {

        }

    }
    public class AppUser : IdentityUser<int>
    {
        public bool IsCharacterCreated { get; set; }
        public int AccountCharacterID { get; set; }
    }
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<CharacterItem>()
            //    .HasKey(c => new { c.CharacterID, c.ItemID });
            base.OnModelCreating(builder);
            builder.Entity<Character>().HasKey(c => new { c.CharacterID });
            builder.Entity<CharacterItem>().HasKey(ci => new { ci.CharacterID, ci.ItemID });

            SeedData(builder);
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Race> Races { get; set; }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CharacterItem> CharacterItems { get; set; }



        public DbSet<Item> Items { get; set; }

        public DbSet<LevellingTable> LevellingTables { get; set; }



        private void SeedData(ModelBuilder builder)
        {

            builder.Entity<Race>().HasData(
                new Race { RaceID = 1, Name = "Olbrzym", BaseAttackDamage = 4, BaseVitality = 3, BaseAgility = 1, BaseDefence = 0, BaseDexterity = 10 },
                new Race { RaceID = 2, Name = "Elf", BaseAttackDamage = 2, BaseVitality = 2, BaseAgility = 4, BaseDefence = 0, BaseDexterity = 4 },
                new Race { RaceID = 3, Name = "Draenei", BaseAttackDamage = 4, BaseVitality = 2, BaseAgility = 3, BaseDefence = 0, BaseDexterity = 3 },
                new Race { RaceID = 4, Name = "Człowiek", BaseAttackDamage = 3, BaseVitality = 2, BaseAgility = 3, BaseDefence = 0, BaseDexterity = 3 }
                );

            builder.Entity<Location>().HasData(
                new Location { LocationID = 1, Name = "Dalur", Description = "Dolina", ReuqiredLevel = 1 },
                new Location { LocationID = 2, Name = "Setberg", Description = "Góry skaliste", ReuqiredLevel = 5 },
                new Location { LocationID = 3, Name = "Leifar", Description = "Ruiny", ReuqiredLevel = 10 }
                );

            builder.Entity<Monster>().HasData(
                new Monster { MonsterID = 1, Name = "Fenrir", Level = 1, AttackDamage = 2, Dexterity = 1, Vitality = 5, Agility = 1, Defence = 2, MiniatureURL = "adres", LocationID = 1 },
                new Monster { MonsterID = 2, Name = "Warg", Level = 2, AttackDamage = 3, Dexterity = 1, Vitality = 6, Agility = 1, Defence = 5, MiniatureURL = "adredss", LocationID = 1 },
                new Monster { MonsterID = 3, Name = "Fafnir", Level = 5, AttackDamage = 1, Dexterity = 1, Vitality = 1, Agility = 1, Defence = 1, MiniatureURL = "adresdsds", LocationID = 1 },
                new Monster { MonsterID = 4, Name = "Manu", Level = 6, AttackDamage = 6, Dexterity = 2, Vitality = 8, Agility = 1, Defence = 10, MiniatureURL = "adresds", LocationID = 2 },
                new Monster { MonsterID = 5, Name = "Sleipnir", Level = 7, AttackDamage = 7, Dexterity = 3, Vitality = 9, Agility = 1, Defence = 11, MiniatureURL = "adrdses", LocationID = 2 }
                );

            builder.Entity<Item>().HasData(
               new Item { ItemID = 1, Name = "Zardzewiała zbroja", RequiredLevel = 1, Rank = 1, ShopPrice =1, MiniatureURL = "", IsUnique = false, Type = "Armor", Defence = 1},
               new Item { ItemID = 2, Name = "Zardzewiały Mieczysław", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Weapon", Damage=1},
               new Item { ItemID = 3, Name = "Zardzewiała Tarcza", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Shield", Defence = 1, Agility=1},
               new Item { ItemID = 4, Name = "Sandały", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Boots", Agility=1},
               new Item { ItemID = 5, Name = "Zardzewiały Hełm", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Helmet", Defence=1},
               new Item { ItemID = 6, Name = "Zardzewiały Pierścień", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Ring", Dexterity = 1},
               new Item { ItemID = 7, Name = "Zardzewiały Naszyjnik", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = false, Type = "Necklace", Vitality = 1 },

               new Item { ItemID = 8, Name = "Stalowa Zbroja", RequiredLevel = 1, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Armor", Vitality = 5 },
               new Item { ItemID = 9, Name = "Stalowy Mieczysław", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Weapon", Damage = 5 },
               new Item { ItemID = 10, Name = "Stalowa Tarcza", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Shield", Defence = 1, Agility = 5 },
               new Item { ItemID = 11, Name = "Skórzane Buty", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Boots", Agility = 5 },
               new Item { ItemID = 12, Name = "Stalowy Hełm", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Helmet", Defence = 5 },
               new Item { ItemID = 13, Name = "Stalowy Pierścień", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Ring", Dexterity = 5 },
               new Item { ItemID = 14, Name = "Stalowy Naszyjnik", RequiredLevel = 5, Rank = 1, ShopPrice = 1, MiniatureURL = "", IsUnique = true, Type = "Necklace", Vitality = 5 }
                );

            builder.Entity<LevellingTable>().HasData(
                new LevellingTable { LevelID=2, ExperienceNeeded=200},
                new LevellingTable { LevelID = 3, ExperienceNeeded = 400 },
                new LevellingTable { LevelID = 4, ExperienceNeeded = 600 },
                new LevellingTable { LevelID = 5, ExperienceNeeded = 800 },
                new LevellingTable { LevelID = 6, ExperienceNeeded = 1000 },
                new LevellingTable { LevelID = 7, ExperienceNeeded = 1200 },
                new LevellingTable { LevelID = 8, ExperienceNeeded = 1400 },
                new LevellingTable { LevelID = 9, ExperienceNeeded = 1600 },
                new LevellingTable { LevelID = 10, ExperienceNeeded = 1800 }
                );
        }

    }
}
