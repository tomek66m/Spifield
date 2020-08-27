using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.ViewModels
{
    public class CharacterEquipmentVM
    {
        public Item  Item { get;set;}
        public bool IsWielded { get; set; }
        public int Quantity { get; set;}
    }
}
