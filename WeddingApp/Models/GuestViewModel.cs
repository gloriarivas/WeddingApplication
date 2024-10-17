using WeddingAppDatabase.Entities;

namespace WeddingApp.Models
{
    public class GuestViewModel
    {
        public Guests ActiveGuest { get; set; }

        public List<WeddingParty> PartyRoles { get; set; }
    }
}
