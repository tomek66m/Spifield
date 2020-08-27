using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Leaderboard")]
    public class Leaderboard
    {
        // Attributes
        [Key]
        public int LeaderboardID { get; set; }
        [Required]
        public int RankPosition { get; set; }
        // Foreign keys
    }
}
