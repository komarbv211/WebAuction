using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class BidDto
    {
        public int Id { get; set; }
        public int LotId { get; set; }
        public int Amount { get; set; }
        public DateTime BidTime { get; set; }
        public string? BidderId { get; set; }
    }
}
