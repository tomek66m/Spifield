using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.ViewModels
{
    public class AllCharacterInventoryVM
    {
        public List<Item> wieldedItems { get; set; }
        public List<CharacterEquipmentVM> allItems { get; set; }
    }
}
