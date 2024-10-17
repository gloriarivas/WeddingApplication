using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingAppDatabase.Entities
{
    public class Guests
    {
        [Key]
        public int GuestId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }
        
        public string? Email { get; set; }
        
        public string? Address { get; set; }

        public int? WeddingPartyId { get; set; }
        public WeddingParty? WeddingParty { get; set; }
   
        public ICollection<SeatingChart>? SeatingCharts { get; set; }

        public DietaryNeeds? DietaryNeed { get; set; }

        public ICollection<PlusOnes>? PlusOnes { get; set; }

        public ICollection<PlusOnes>? InvitedGuests { get; set; }
    }
}
