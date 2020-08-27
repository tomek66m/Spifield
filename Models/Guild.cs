using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Guild")]
    public class Guild
    {
        // Attributes
        [Key]
        public int GuildID { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Nazwa musi mieć mniej niż 25 znaków")]
        public string Name { get; set; }
        [Required]
        public int NumberOfMembers { get; set; }
        [Required]
        public int GuildOwnerID { get; set; }

        // Foreign keys
    }
}
