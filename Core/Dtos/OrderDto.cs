using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public string? UserId { get; set; }
        public int FinalPrice { get; set; }
        public DateTime DateWon { get; set; }
    }
}
