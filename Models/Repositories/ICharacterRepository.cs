using Spifield.Model;
using Spifield.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public interface ICharacterRepository
    {
        void AddCharacter(Character character);
        void AddItem(int id, int characterid, int quantity = 1);
        Character GetCharacter(int characterID);
    }
}
