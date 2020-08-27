using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Character")]
    public class Character
    {
        // Attributes
        [Key]
        public int CharacterID { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage ="Nazwa musi mieć mniej niż 20 znaków")]
        public string Name { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int StatPoints { get; set; }
        [Required]
        public int AdditionalAtttackDamage { get; set; }
        [Required]
        public int AdditionalDexterity { get; set; }
        [Required]
        public int AdditionalVitality { get; set; }
        [Required]
        public int AdditionalAgility { get; set; }
        [Required]
        public int AdditionalDefence { get; set; }
        [Required]
        public int SilfrQuantity { get; set; }

        // Foreign keys
        [ForeignKey("CharacterID")]
        public virtual ICollection<CharacterItem> CharacterItems { get; set; }
        [ForeignKey("RaceID")]
        public virtual Race Race { get; set; }
        public int RaceID { get; set; }

    }
}
