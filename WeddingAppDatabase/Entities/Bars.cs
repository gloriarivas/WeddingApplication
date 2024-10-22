using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Bars
    {
        [Key]
        public int BarId { get; set; }

        public string? BarName { get; set; }

        public string? Description { get; set; }

        public string? SpecialInstructions { get; set; }

        public string? HoursStart { get; set; }

        public string? HoursEnd { get; set; }
    }
}
