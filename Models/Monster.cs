using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Monster")]
    public class Monster
    {
        // Attributes
        [Key]
        public int MonsterID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int AttackDamage { get; set; }
        [Required]
        public int Dexterity { get; set; }
        [Required]
        public int Vitality { get; set; }
        [Required]
        public int Agility { get; set; }
        [Required]
        public int Defence { get; set; }
        public string MiniatureURL { get; set; }
        // Foreign Keys
        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        public int LocationID { get; set; }
    }
}
