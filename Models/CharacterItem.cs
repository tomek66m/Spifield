using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    public class CharacterItem
    {
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }
        public bool IsCurrentlyWielded { get; set; }
        public int Quantity { get; set; }
    }
}
