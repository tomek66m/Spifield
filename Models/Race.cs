using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Race")]
    public class Race
    {
        // Attributes
        [Key]
        public int RaceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int BaseAttackDamage { get; set; }
        [Required]
        public int BaseDexterity { get; set; }
        [Required]
        public int BaseVitality { get; set; }
        [Required]
        public int BaseAgility { get; set; }
        [Required]
        public int BaseDefence { get; set; }


        // Foreign keys

        public virtual IEnumerable<Character> Character { get; set; }
    }
}
