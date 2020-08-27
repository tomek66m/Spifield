using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Model
{
    [Table("Auction")]
    public class Auction
    {
        // Attributes
        [Key]
        public int AuctionID { get; set; }
        [Required]
        public int Price { get; set; }

        // Foreign keys
    }
}
