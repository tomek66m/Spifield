using Spifield.Model;
using Spifield.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _appDbContext;

        public CharacterRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }
        public void AddCharacter(Character character)
        {
            _appDbContext.Characters.Add(character);
            _appDbContext.SaveChanges();
        }

        public Character GetCharacter(int characterID)
        {
            return _appDbContext.Characters.FirstOrDefault(x => x.CharacterID == characterID);
        }

        public void AddItem(int id, int characterid, int quantity= 1)
        {
            var newItem = new CharacterItem { CharacterID = characterid, ItemID = id, Quantity = quantity, IsCurrentlyWielded = false };
            _appDbContext.CharacterItems.Add(newItem);
            _appDbContext.SaveChanges();
        }

    }
}
