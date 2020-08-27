using Spifield.Model;
using Spifield.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public interface IItemRepository
    {
        void addWeapon(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Weapon", int _damage = 1);
        void addArmor(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Armor", int _defence=1);
        void addShield(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Shield", int _defence = 1, int _agility=1);
        void addBoots(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Boots", int _agility=1);
        void addHelmet(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Helmet", int _defence = 1);
        void addNecklace(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Armor", int _vitality = 1);
        void addRing(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Ring", int _dexterity = 1);

        List<Item> GetCharacterWieldedItems(int characterID);

        List<CharacterEquipmentVM> GetAllCharacterItems(int characterID);

        void equipItem(int _itemID, string _type,  int _characterID);

    }
}
