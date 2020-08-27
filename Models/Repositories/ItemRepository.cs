using Spifield.Model;
using Spifield.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }

        public void addArmor(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Armor", int _defence = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Defence = _defence };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addBoots(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Boots", int _agility = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Agility=_agility };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addHelmet(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Helmet", int _defence = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Defence=_defence};
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addNecklace(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Armor", int _vitality = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Vitality=_vitality };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addRing(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Ring", int _dexterity = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Dexterity=_dexterity };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addShield(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Shield", int _defence = 1, int _agility = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Defence = _defence, Agility = _agility };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void addWeapon(string _name, int _requiredLevel, int _rank, int _shopPrice, string _miniatureURL, bool _isUnique = false, string _type = "Weapon", int _damage = 1)
        {
            Item temp = new Item { Name = _name, RequiredLevel = _requiredLevel, Rank = _rank, ShopPrice = _shopPrice, MiniatureURL = _miniatureURL, IsUnique = _isUnique, Type = _type, Damage=_damage };
            _appDbContext.Items.Add(temp);
            _appDbContext.SaveChanges();
        }

        public void equipItem(int _itemID, string _type, int _characterID)
        {
            // sciaganie zalozonego itemu
            foreach(var x in _appDbContext.CharacterItems.ToList())
            {
                if(x.IsCurrentlyWielded && x.CharacterID==_characterID)
                {
                    if(_appDbContext.Items.FirstOrDefault(c=>c.ItemID==x.ItemID).Type == _type)
                    {
                        x.IsCurrentlyWielded = false;
                        break;
                    }
                }
            }

            // zalozenie nowego itemy
            _appDbContext.CharacterItems.FirstOrDefault(x => x.ItemID == _itemID && x.CharacterID == _characterID).IsCurrentlyWielded = true;
            _appDbContext.SaveChanges();

        }

        public List<CharacterEquipmentVM> GetAllCharacterItems(int characterID)
        {
            List<CharacterEquipmentVM> result = new List<CharacterEquipmentVM>();

            List<Item> ItemsThatCharacterOwns = new List<Item>();
            
            foreach(var x in _appDbContext.CharacterItems.ToList().Where(c=>c.CharacterID==characterID))
            {
                CharacterEquipmentVM tempVM = new CharacterEquipmentVM();
                Item temp = _appDbContext.Items.FirstOrDefault(c => c.ItemID == x.ItemID);
                tempVM.Item = temp;
                tempVM.Quantity = x.Quantity;
                tempVM.IsWielded = x.IsCurrentlyWielded;
                result.Add(tempVM);
            }

            return result;

        }

        public List<Item> GetCharacterWieldedItems(int characterID)
        {
            List<Item> result = new List<Item>();

            foreach(var x in _appDbContext.CharacterItems.ToList().Where(c=>c.CharacterID == characterID))
            {
                if (x.IsCurrentlyWielded)
                    result.Add(_appDbContext.Items.FirstOrDefault(c => c.ItemID == x.ItemID));
            }

            return result;
        }
    }
}
