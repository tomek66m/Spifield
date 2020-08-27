using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    // MAIN CLASS for ITEMS
    [Table("Item")]
    public class Item
    {
        // Attributes
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        [Required]
        public int Rank { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public bool IsUnique { get; set; }
        [Required]
        public int ShopPrice { get; set; }
        [Required]
        public string MiniatureURL { get; set; }

        // detailed items
        public int Damage { get; set; }
        public int Defence { get; set; }
        public int Agility { get; set; }
        public int Vitality { get; set; }
        public int Dexterity { get; set; }

        // Foreign Keys
        [ForeignKey("ItemID")]
        public virtual ICollection<CharacterItem> CharacterItems { get; set; }
    }

}
