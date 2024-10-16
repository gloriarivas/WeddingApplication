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

        public string? DescriptionWomen { get; set; }

        public string? BannedItemsWomen { get; set; }

        public string? DescriptionMen { get; set; }

        public string? BannedItemsMen { get; set; }

        public ICollection<Restaurants>? Restaurants { get; set; }
    }
}
