using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int LotId { get; set; }

        public Lot? Lot { get; set; }

        [Required]
        public string UserId { get; set; }

        public User? User { get; set; }

        public int FinalPrice { get; set; }

        public DateTime DateWon { get; set; }
    }
}
