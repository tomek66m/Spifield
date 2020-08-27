using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models
{
    public class LevellingTable
    {
        [Key]
        public int LevelID { get; set; }
        [Required]
        public int ExperienceNeeded { get; set; }
    }
}
