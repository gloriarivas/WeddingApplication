using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class DietaryNeeds
    {
        [Key]
        public int DietNeedId { get; set; }

        public int GuestId { get; set; }
        public Guests? Guest { get; set; }

        public string? Restrictions { get; set; }
        
    }
}
