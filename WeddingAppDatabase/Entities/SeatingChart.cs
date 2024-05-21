using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class SeatingChart
    {
        [Key]
        public int SeatId { get; set; }

        public int TableId { get; set; }
        public Tables? Table { get; set; }

        public int GuestId { get; set; }
        public Guests? Guest { get; set; }

        public int SeatNumber { get; set; }

        public decimal YCoord { get; set; }

        public decimal XCoord { get; set; }
    }
}
