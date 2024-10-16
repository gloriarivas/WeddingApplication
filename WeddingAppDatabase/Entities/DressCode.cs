using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class DressCode
    {
        [Key]
        public int DressCodeId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? BannedItems { get; set; }

        public ICollection<Restaurants>? Restaurants { get; set; }
    }
}
