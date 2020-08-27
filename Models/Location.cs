using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Location")]
    public class Location
    {
        // Attributes
        [Key]
        public int LocationID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ReuqiredLevel { get; set; }

        // Foreign Keys

        public Monster Monster { get; set; }
    }
}
