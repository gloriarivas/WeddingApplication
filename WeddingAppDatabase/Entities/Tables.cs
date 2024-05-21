using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Tables
    {
        [Key]
        public int TableId { get; set; }

        public string? TableName { get; set; }

        public int NumberOfSeats { get; set; }

        public ICollection<SeatingChart> SeatingCharts { get; set; }
    }
}
